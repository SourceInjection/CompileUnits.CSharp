parser grammar CSharpParser;
@parser::header {#pragma warning disable 3021}

options {
    tokenVocab = CSharpLexer;
    superClass = CompileUnits.CSharp.Base.CSharpParserBase;
}

// entry point
compilation_unit
    : BYTE_ORDER_MARK? extern_alias_directives? using_directives? global_attribute_section* namespace_member_declarations? EOF
    ;

//B.2 Syntactic grammar

//B.2.1 Basic concepts

namespace_or_type_name
    : (identifier type_argument_list? | qualified_alias_member) 
      ( DOT identifier type_argument_list? )*
    ;

//B.2.2 Types
type_
    : base_type (INTERR | rank_specifier | STAR)*
    ;

base_type
    : simple_type
    | class_type // represents types: enum, class, interface, delegate, type_parameter
    | VOID STAR
    | tuple_type
    ;

tuple_type
    : OPEN_PARENS tuple_element (COMMA tuple_element)+ CLOSE_PARENS
    ;

tuple_element
    : type_ identifier?
    ;

simple_type
    : numeric_type
    | BOOL
    ;

numeric_type
    : integral_type
    | floating_point_type
    | DECIMAL
    ;

integral_type
    : enum_base_type
    | CHAR
    ;

enum_base_type
    : SBYTE
    | BYTE
    | SHORT
    | USHORT
    | INT
    | UINT
    | LONG
    | ULONG
    ;

floating_point_type
    : FLOAT
    | DOUBLE
    ;

/** namespace_or_type_name, OBJECT, STRING */
class_type
    : namespace_or_type_name
    | OBJECT
    | DYNAMIC
    | STRING
    ;

type_argument_list
    : LT type_ (COMMA type_)* GT
    ;

//B.2.4 Expressions
argument_list
    : argument (COMMA argument)*
    ;

argument
    : (identifier COLON)? refout = (REF | OUT | IN)? (expression | (VAR | type_) expression)
    ;

expression
    : assignment
    | non_assignment_expression
    | REF non_assignment_expression
    ;

non_assignment_expression
    : lambda_expression
    | query_expression
    | conditional_expression
    ;

assignment
    : unary_expression assignment_operator expression
    | unary_expression OP_COALESCING_ASSIGNMENT throwable_expression
    ;

assignment_operator
    : ASSIGNMENT
    | OP_ADD_ASSIGNMENT
    | OP_SUB_ASSIGNMENT
    | OP_MULT_ASSIGNMENT
    | OP_DIV_ASSIGNMENT
    | OP_MOD_ASSIGNMENT
    | OP_AND_ASSIGNMENT
    | OP_OR_ASSIGNMENT
    | OP_XOR_ASSIGNMENT
    | OP_LEFT_SHIFT_ASSIGNMENT
    | OP_RIGHT_SHIFT_ASSIGNMENT
    ;

conditional_expression
    : null_coalescing_expression (INTERR throwable_expression COLON throwable_expression)?
    ;

null_coalescing_expression
    : conditional_or_expression (OP_COALESCING (null_coalescing_expression | throw_expression))?
    ;

conditional_or_expression
    : conditional_and_expression (OP_OR conditional_and_expression)*
    ;

conditional_and_expression
    : inclusive_or_expression (OP_AND inclusive_or_expression)*
    ;

inclusive_or_expression
    : exclusive_or_expression (BITWISE_OR exclusive_or_expression)*
    ;

exclusive_or_expression
    : and_expression (CARET and_expression)*
    ;

and_expression
    : equality_expression (AMP equality_expression)*
    ;

equality_expression
    : relational_expression ((OP_EQ | OP_NE) relational_expression)*
    ;

relational_expression
    : shift_expression (relational_operator shift_expression | IS primary_pattern | AS type_)*
    ;

relational_operator
    : LT | GT | OP_LE | OP_GE
    ;

primary_pattern
    : parenthesized_pattern
    | type_pattern
    | relational_pattern
    ;

parenthesized_pattern
    : OPEN_PARENS pattern CLOSE_PARENS
    ;

pattern
    : disjunctive_pattern
    ;

disjunctive_pattern
    : disjunctive_pattern OR conjunctive_pattern
    | conjunctive_pattern
    ;

conjunctive_pattern
    : conjunctive_pattern AND negated_pattern
    | negated_pattern
    ;

negated_pattern
    : NOT negated_pattern
    | primary_pattern
    ;

relational_pattern
    : relational_operator relational_expression
    ;

type_pattern
    : isType
    ;

shift_expression
    : additive_expression ((OP_LEFT_SHIFT | right_shift) additive_expression)*
    ;

additive_expression
    : multiplicative_expression ((PLUS | MINUS) multiplicative_expression)*
    ;

multiplicative_expression
    : switch_expression ((STAR | DIV | PERCENT) switch_expression)*
    ;

switch_expression
    : range_expression (SWITCH OPEN_BRACE (switch_expression_arms COMMA?)? CLOSE_BRACE)?
    ;

switch_expression_arms
    : switch_expression_arm (COMMA switch_expression_arm)*
    ;

switch_expression_arm
    : expression case_guard? RIGHT_ARROW throwable_expression
    ;

range_expression
    : unary_expression
    | unary_expression? OP_RANGE unary_expression?
    ;

// https://msdn.microsoft.com/library/6a71f45d(v=vs.110).aspx
unary_expression
    : cast_expression
    | primary_expression
    | PLUS unary_expression
    | MINUS unary_expression
    | BANG unary_expression
    | TILDE unary_expression
    | OP_INC unary_expression
    | OP_DEC unary_expression
    | AWAIT unary_expression // C# 5
    | AMP unary_expression
    | STAR unary_expression
    | CARET unary_expression // C# 8 ranges
    ;

cast_expression
    : OPEN_PARENS type_ CLOSE_PARENS unary_expression
    ;

primary_expression // Null-conditional operators C# 6: https://msdn.microsoft.com/en-us/library/dn986595.aspx
    : pe = primary_expression_start BANG? bracket_expression* BANG? (
        (member_access | method_invocation | OP_INC | OP_DEC | OP_PTR identifier) BANG? bracket_expression* BANG?
    )*
    ;

primary_expression_start
    : literal                                                                                # literalExpression
    | identifier type_argument_list?                                                         # simpleNameExpression
    | OPEN_PARENS expression CLOSE_PARENS                                                    # parenthesisExpressions
    | predefined_type                                                                        # memberAccessExpression
    | qualified_alias_member                                                                 # memberAccessExpression
    | LITERAL_ACCESS                                                                         # literalAccessExpression
    | THIS                                                                                   # thisReferenceExpression
    | BASE (DOT identifier type_argument_list? | OPEN_BRACKET expression_list CLOSE_BRACKET) # baseAccessExpression
    | NEW (
        type_? (
            object_creation_expression
            | object_or_collection_initializer
            | OPEN_BRACKET expression_list CLOSE_BRACKET rank_specifier* array_initializer?
            | rank_specifier+ array_initializer
        )
        | anonymous_object_initializer
        | rank_specifier array_initializer
    )                                                                                               # objectCreationExpression
    | OPEN_PARENS argument ( COMMA argument)+ CLOSE_PARENS                                          # tupleExpression
    | TYPEOF OPEN_PARENS (unbound_type_name | type_ | VOID) CLOSE_PARENS                            # typeofExpression
    | CHECKED OPEN_PARENS expression CLOSE_PARENS                                                   # checkedExpression
    | UNCHECKED OPEN_PARENS expression CLOSE_PARENS                                                 # uncheckedExpression
    | DEFAULT (OPEN_PARENS type_ CLOSE_PARENS)?                                                     # defaultValueExpression
    | ASYNC? DELEGATE (OPEN_PARENS explicit_anonymous_function_parameter_list? CLOSE_PARENS)? block # anonymousMethodExpression
    | SIZEOF OPEN_PARENS type_ CLOSE_PARENS                                                         # sizeofExpression
    | NAMEOF OPEN_PARENS (identifier DOT)* identifier CLOSE_PARENS                                  # nameofExpression
    ;

throwable_expression
    : expression
    | throw_expression
    ;

throw_expression
    : THROW expression
    ;

member_access
    : INTERR? DOT identifier type_argument_list?
    ;

bracket_expression
    : INTERR? OPEN_BRACKET indexer_argument (COMMA indexer_argument)* CLOSE_BRACKET
    ;

indexer_argument
    : (identifier COLON)? expression
    ;

predefined_type
    : BOOL
    | BYTE
    | CHAR
    | DECIMAL
    | DOUBLE
    | FLOAT
    | INT
    | LONG
    | OBJECT
    | SBYTE
    | SHORT
    | STRING
    | UINT
    | ULONG
    | USHORT
    ;

expression_list
    : expression (COMMA expression)*
    ;

object_or_collection_initializer
    : object_initializer
    | collection_initializer
    ;

object_initializer
    : OPEN_BRACE (member_initializer_list COMMA?)? CLOSE_BRACE
    ;

member_initializer_list
    : member_initializer (COMMA member_initializer)*
    ;

member_initializer
    : (identifier | OPEN_BRACKET expression CLOSE_BRACKET) ASSIGNMENT initializer_value // C# 6
    ;

initializer_value
    : expression
    | object_or_collection_initializer
    ;

collection_initializer
    : OPEN_BRACE element_initializer (COMMA element_initializer)* COMMA? CLOSE_BRACE
    ;

element_initializer
    : non_assignment_expression
    | OPEN_BRACE expression_list CLOSE_BRACE
    ;

anonymous_object_initializer
    : OPEN_BRACE (member_declarator_list COMMA?)? CLOSE_BRACE
    ;

member_declarator_list
    : member_declarator (COMMA member_declarator)*
    ;

member_declarator
    : primary_expression
    | identifier ASSIGNMENT expression
    ;

unbound_type_name
    : identifier (generic_dimension_specifier? | DOUBLE_COLON identifier generic_dimension_specifier?) (
        DOT identifier generic_dimension_specifier?
    )*
    ;

generic_dimension_specifier
    : LT COMMA* GT
    ;

isType
    : base_type (rank_specifier | STAR)* INTERR? isTypePatternArms? identifier?
    ;

isTypePatternArms
    : OPEN_BRACE isTypePatternArm (COMMA isTypePatternArm)* CLOSE_BRACE
    ;

isTypePatternArm
    : identifier COLON expression
    ;

lambda_expression
    : ASYNC? anonymous_function_signature RIGHT_ARROW anonymous_function_body
    ;

anonymous_function_signature
    : OPEN_PARENS CLOSE_PARENS
    | OPEN_PARENS explicit_anonymous_function_parameter_list CLOSE_PARENS
    | OPEN_PARENS implicit_anonymous_function_parameter_list CLOSE_PARENS
    | identifier
    ;

explicit_anonymous_function_parameter_list
    : explicit_anonymous_function_parameter (COMMA explicit_anonymous_function_parameter)*
    ;

explicit_anonymous_function_parameter
    : refout = (REF | OUT | IN)? type_ identifier
    ;

implicit_anonymous_function_parameter_list
    : identifier (COMMA identifier)*
    ;

anonymous_function_body
    : throwable_expression
    | block
    ;

query_expression
    : from_clause query_body
    ;

from_clause
    : FROM type_? identifier IN expression
    ;

query_body
    : query_body_clause* select_or_group_clause query_continuation?
    ;

query_body_clause
    : from_clause
    | let_clause
    | where_clause
    | combined_join_clause
    | orderby_clause
    ;

let_clause
    : LET identifier ASSIGNMENT expression
    ;

where_clause
    : WHERE expression
    ;

combined_join_clause
    : JOIN type_? identifier IN expression ON expression EQUALS expression (INTO identifier)?
    ;

orderby_clause
    : ORDERBY ordering (COMMA ordering)*
    ;

ordering
    : expression dir = (ASCENDING | DESCENDING)?
    ;

select_or_group_clause
    : SELECT expression
    | GROUP expression BY expression
    ;

query_continuation
    : INTO identifier query_body
    ;

//B.2.5 Statements
statement
    : labeled_Statement
    | declarationStatement
    | embedded_statement
    ;

declarationStatement
    : local_variable_declaration SEMICOLON
    | local_constant_declaration SEMICOLON
    | local_function_declaration
    ;

local_function_declaration
    : local_function_header local_function_body
    ;

local_function_header
    : local_function_modifiers? return_type identifier type_parameter_list? OPEN_PARENS formal_parameter_list? CLOSE_PARENS
        type_parameter_constraints_clauses?
    ;

local_function_modifiers
    : (ASYNC | UNSAFE) STATIC?
    | STATIC (ASYNC | UNSAFE)
    ;

local_function_body
    : block
    | RIGHT_ARROW throwable_expression SEMICOLON
    ;

labeled_Statement
    : identifier COLON statement
    ;

embedded_statement
    : block
    | simple_embedded_statement
    ;

simple_embedded_statement
    : SEMICOLON            # theEmptyStatement
    | expression SEMICOLON # expressionStatement

    // selection statements
    | IF OPEN_PARENS expression CLOSE_PARENS if_body (ELSE if_body)?                    # ifStatement
    | SWITCH OPEN_PARENS expression CLOSE_PARENS OPEN_BRACE switch_section* CLOSE_BRACE # switchStatement

    // iteration statements
    | WHILE OPEN_PARENS expression CLOSE_PARENS embedded_statement                                            # whileStatement
    | DO embedded_statement WHILE OPEN_PARENS expression CLOSE_PARENS SEMICOLON                                     # doStatement
    | FOR OPEN_PARENS for_initializer? SEMICOLON expression? SEMICOLON for_iterator? CLOSE_PARENS embedded_statement      # forStatement
    | AWAIT? FOREACH OPEN_PARENS local_variable_type identifier IN expression CLOSE_PARENS embedded_statement # foreachStatement

    // jump statements
    | BREAK SEMICOLON                                                              # breakStatement
    | CONTINUE SEMICOLON                                                           # continueStatement
    | GOTO (identifier | CASE expression | DEFAULT) SEMICOLON                      # gotoStatement
    | RETURN expression? SEMICOLON                                                 # returnStatement
    | THROW expression? SEMICOLON                                                  # throwStatement
    | TRY block (catch_clauses finally_clause? | finally_clause)             # tryStatement
    | CHECKED block                                                          # checkedStatement
    | UNCHECKED block                                                        # uncheckedStatement
    | LOCK OPEN_PARENS expression CLOSE_PARENS embedded_statement            # lockStatement
    | USING OPEN_PARENS resource_acquisition CLOSE_PARENS embedded_statement # usingStatement
    | YIELD (RETURN expression | BREAK) SEMICOLON                                  # yieldStatement

    // unsafe statements
    | UNSAFE block                                                                             # unsafeStatement
    | FIXED OPEN_PARENS pointer_type fixed_pointer_declarators CLOSE_PARENS embedded_statement # fixedStatement
    ;

block
    : OPEN_BRACE statement_list? CLOSE_BRACE
    ;

local_variable_declaration
    : (USING | REF | REF READONLY)? local_variable_type local_variable_declarator (
        COMMA local_variable_declarator { this.IsLocalVariableDeclaration() }?
    )*
    | FIXED pointer_type fixed_pointer_declarators
    ;

local_variable_type
    : VAR
    | type_
    ;

local_variable_declarator
    : identifier (ASSIGNMENT REF? local_variable_initializer)?
    ;

local_variable_initializer
    : expression
    | array_initializer
    | stackalloc_initializer
    ;

local_constant_declaration
    : CONST type_ constant_declarators
    ;

if_body
    : block
    | simple_embedded_statement
    ;

switch_section
    : switch_label+ statement_list
    ;

switch_label
    : CASE expression case_guard? COLON
    | DEFAULT COLON
    ;

case_guard
    : WHEN expression
    ;

statement_list
    : statement+
    ;

for_initializer
    : local_variable_declaration
    | expression (COMMA expression)*
    ;

for_iterator
    : expression (COMMA expression)*
    ;

catch_clauses
    : specific_catch_clause specific_catch_clause* general_catch_clause?
    | general_catch_clause
    ;

specific_catch_clause
    : CATCH OPEN_PARENS class_type identifier? CLOSE_PARENS exception_filter? block
    ;

general_catch_clause
    : CATCH exception_filter? block
    ;

exception_filter // C# 6
    : WHEN OPEN_PARENS expression CLOSE_PARENS
    ;

finally_clause
    : FINALLY block
    ;

resource_acquisition
    : local_variable_declaration
    | expression
    ;

//B.2.6 Namespaces;
namespace_declaration
    : NAMESPACE qi = qualified_identifier namespace_body SEMICOLON?
    ;

qualified_identifier
    : identifier (DOT identifier)*
    ;

namespace_body
    : OPEN_BRACE extern_alias_directives? using_directives? namespace_member_declarations? CLOSE_BRACE
    ;

extern_alias_directives
    : extern_alias_directive+
    ;

extern_alias_directive
    : EXTERN ALIAS identifier SEMICOLON
    ;

using_directives
    : using_directive+
    ;

using_directive
    : using_alias_directive
    | using_static_directive
    | using_namespace_directive
    ;

using_alias_directive
    : USING identifier ASSIGNMENT namespace_or_type_name SEMICOLON
    ;

using_static_directive
    : USING STATIC namespace_or_type_name SEMICOLON
    ;

using_namespace_directive
    : USING namespace_or_type_name SEMICOLON
    ;

namespace_member_declarations
    : namespace_member_declaration+
    ;

namespace_member_declaration
    : namespace_declaration
    | type_declaration
    ;

type_declaration
    : attributes? all_member_modifiers? (
        class_definition
        | struct_definition
        | interface_definition
        | enum_definition
        | delegate_definition
    )
    ;

qualified_alias_member
    : identifier DOUBLE_COLON identifier type_argument_list?
    ;

//B.2.7 Classes;
type_parameter_list
    : LT type_parameter (COMMA type_parameter)* GT
    ;

type_parameter
    : attributes? identifier
    ;

class_base
    : COLON class_type (COMMA namespace_or_type_name)*
    ;

interface_type_list
    : namespace_or_type_name (COMMA namespace_or_type_name)*
    ;

type_parameter_constraints_clauses
    : type_parameter_constraints_clause+
    ;

type_parameter_constraints_clause
    : WHERE identifier COLON type_parameter_constraints
    ;

type_parameter_constraints
    : constructor_constraint
    | primary_constraint (COMMA secondary_constraints)? (COMMA constructor_constraint)?
    ;

primary_constraint
    : CLASS INTERR?
    | STRUCT
    | UNMANAGED
    | NOTNULL
    | DEFAULT
    | class_type
    ;

// namespace_or_type_name includes identifier
secondary_constraints
    : namespace_or_type_name (COMMA namespace_or_type_name)*
    ;

constructor_constraint
    : NEW OPEN_PARENS CLOSE_PARENS
    ;

class_body
    : OPEN_BRACE class_member_declarations? CLOSE_BRACE
    ;

class_member_declarations
    : class_member_declaration+
    ;

class_member_declaration
    : attributes? all_member_modifiers? (common_member_declaration | destructor_definition)
    ;

all_member_modifiers
    : all_member_modifier+
    ;

all_member_modifier
    : NEW
    | PUBLIC
    | PROTECTED
    | INTERNAL
    | PRIVATE
    | READONLY
    | VOLATILE
    | VIRTUAL
    | SEALED
    | OVERRIDE
    | ABSTRACT
    | STATIC
    | UNSAFE
    | EXTERN
    | PARTIAL
    | ASYNC // C# 5
    ;

// represents the intersection of struct_member_declaration and class_member_declaration
common_member_declaration
    : constant_declaration
    | typed_member_declaration
    | event_declaration
    | conversion_operator_declarator
    | constructor_declaration
    | VOID method_declaration
    | class_definition
    | struct_definition
    | interface_definition
    | enum_definition
    | delegate_definition
    ;

typed_member_declaration
    : (REF | READONLY REF | REF READONLY)? type_ (
        namespace_or_type_name DOT (operator_declaration | indexer_declaration)
        | method_declaration
        | property_declaration
        | indexer_declaration
        | operator_declaration
        | field_declaration
    )
    ;

constant_declarators
    : constant_declarator (COMMA constant_declarator)*
    ;

constant_declarator
    : identifier ASSIGNMENT expression
    ;

variable_declarators
    : variable_declarator (COMMA variable_declarator)*
    ;

variable_declarator
    : identifier (ASSIGNMENT variable_initializer)?
    ;

variable_initializer
    : expression
    | array_initializer
    ;

return_type
    : type_
    | VOID
    ;

member_name
    : namespace_or_type_name
    ;

method_body
    : block
    | SEMICOLON
    ;

formal_parameter_list
    : parameter_array
    | fixed_parameters (COMMA parameter_array)?
    ;

fixed_parameters
    : fixed_parameter (COMMA fixed_parameter)*
    ;

fixed_parameter
    : attributes? parameter_modifier? arg_declaration
    | ARGLIST
    ;

parameter_modifier
    : REF
    | OUT
    | IN
    | REF THIS
    | IN THIS
    | THIS
    ;

parameter_array
    : attributes? PARAMS array_type identifier
    ;

accessor_declarations
    : attrs = attributes? mods = accessor_modifier? (
        GET accessor_body set_accessor_declaration?
        | SET accessor_body get_accessor_declaration?
    )
    ;

get_accessor_declaration
    : attributes? accessor_modifier? GET accessor_body
    ;

set_accessor_declaration
    : attributes? accessor_modifier? SET accessor_body
    ;

accessor_modifier
    : PROTECTED
    | INTERNAL
    | PRIVATE
    | PROTECTED INTERNAL
    | INTERNAL PROTECTED
    ;

accessor_body
    : block
    | SEMICOLON
    ;

event_accessor_declarations
    : attributes? (ADD block remove_accessor_declaration | REMOVE block add_accessor_declaration)
    ;

add_accessor_declaration
    : attributes? ADD block
    ;

remove_accessor_declaration
    : attributes? REMOVE block
    ;

overloadable_operator
    : PLUS
    | MINUS
    | BANG
    | TILDE
    | OP_INC
    | OP_DEC
    | TRUE
    | FALSE
    | STAR
    | DIV
    | PERCENT
    | AMP
    | BITWISE_OR
    | CARET
    | OP_LEFT_SHIFT
    | right_shift
    | OP_EQ
    | OP_NE
    | GT
    | LT
    | OP_GE
    | OP_LE
    ;

right_shift
    : first = GT second = GT {$first.index + 1 == $second.index}?
    ;

conversion_operator_declarator
    : (IMPLICIT | EXPLICIT) OPERATOR type_ OPEN_PARENS arg_declaration CLOSE_PARENS 
      (body | RIGHT_ARROW throwable_expression SEMICOLON) // C# 6
    ;

constructor_initializer
    : COLON (BASE | THIS) OPEN_PARENS argument_list? CLOSE_PARENS
    ;

body
    : block
    | SEMICOLON
    ;

struct_body
    : OPEN_BRACE struct_member_declaration* CLOSE_BRACE
    ;

struct_member_declaration
    : attributes? all_member_modifiers? (
        common_member_declaration
        | FIXED type_ fixed_size_buffer_declarator+ SEMICOLON
    )
    ;

//B.2.9 Arrays
array_type
    : base_type ((STAR | INTERR)* rank_specifier)+
    ;

rank_specifier
    : OPEN_BRACKET COMMA* CLOSE_BRACKET
    ;

array_initializer
    : OPEN_BRACE (variable_initializer (COMMA variable_initializer)* COMMA?)? CLOSE_BRACE
    ;

//B.2.10 Interfaces
variant_type_parameter_list
    : LT variant_type_parameter (COMMA variant_type_parameter)* GT
    ;

variant_type_parameter
    : attributes? variance_annotation? identifier
    ;

variance_annotation
    : IN
    | OUT
    ;

interface_base
    : COLON interface_type_list
    ;

interface_body // ignored in csharp 8
    : OPEN_BRACE interface_member_declaration* CLOSE_BRACE
    ;

interface_member_declaration
    : attributes? NEW? (
        UNSAFE? (REF | REF READONLY | READONLY REF)? type_ (
            identifier type_parameter_list? OPEN_PARENS formal_parameter_list? CLOSE_PARENS type_parameter_constraints_clauses? SEMICOLON
            | identifier OPEN_BRACE interface_accessors CLOSE_BRACE
            | THIS OPEN_BRACKET formal_parameter_list CLOSE_BRACKET OPEN_BRACE interface_accessors CLOSE_BRACE
        )
        | UNSAFE? VOID identifier type_parameter_list? OPEN_PARENS formal_parameter_list? CLOSE_PARENS type_parameter_constraints_clauses? SEMICOLON
        | EVENT type_ identifier SEMICOLON
    )
    ;

interface_accessors
    : attributes? (GET SEMICOLON (attributes? SET SEMICOLON)? | SET SEMICOLON (attributes? GET SEMICOLON)?)
    ;

//B.2.11 Enums
enum_base
    : COLON enum_base_type
    ;

enum_body
    : OPEN_BRACE (enum_member_declaration (COMMA enum_member_declaration)* COMMA?)? CLOSE_BRACE
    ;

enum_member_declaration
    : attributes? identifier (ASSIGNMENT expression)?
    ;

//B.2.12 Delegates

//B.2.13 Attributes
global_attribute_section
    : OPEN_BRACKET global_attribute_target COLON attribute_list COMMA? CLOSE_BRACKET
    ;

global_attribute_target
    : keyword
    | identifier
    ;

attributes
    : attribute_section+
    ;

attribute_section
    : OPEN_BRACKET (attribute_target COLON)? attribute_list COMMA? CLOSE_BRACKET
    ;

attribute_target
    : keyword
    | identifier
    ;

attribute_list
    : attribute (COMMA attribute)*
    ;

attribute
    : namespace_or_type_name (
        OPEN_PARENS (attribute_argument (COMMA attribute_argument)*)? CLOSE_PARENS
    )?
    ;

attribute_argument
    : (identifier COLON)? expression
    ;

//B.3 Grammar extensions for unsafe code
pointer_type
    : (simple_type | class_type) (rank_specifier | INTERR)* STAR
    | VOID STAR
    ;

fixed_pointer_declarators
    : fixed_pointer_declarator (COMMA fixed_pointer_declarator)*
    ;

fixed_pointer_declarator
    : identifier ASSIGNMENT fixed_pointer_initializer
    ;

fixed_pointer_initializer
    : AMP? expression
    | stackalloc_initializer
    ;

fixed_size_buffer_declarator
    : identifier OPEN_BRACKET expression CLOSE_BRACKET
    ;

stackalloc_initializer
    : STACKALLOC type_ OPEN_BRACKET expression CLOSE_BRACKET
    | STACKALLOC type_? OPEN_BRACKET expression? CLOSE_BRACKET OPEN_BRACE expression (COMMA expression)* COMMA? CLOSE_BRACE
    ;

literal
    : boolean_literal
    | string_literal
    | INTEGER_LITERAL
    | HEX_INTEGER_LITERAL
    | BIN_INTEGER_LITERAL
    | REAL_LITERAL
    | CHARACTER_LITERAL
    | NULL_
    ;

boolean_literal
    : TRUE
    | FALSE
    ;

string_literal
    : interpolated_regular_string
    | interpolated_verbatium_string
    | REGULAR_STRING
    | VERBATIUM_STRING
    ;

interpolated_regular_string
    : INTERPOLATED_REGULAR_STRING_START interpolated_regular_string_part* DOUBLE_QUOTE_INSIDE
    ;

interpolated_verbatium_string
    : INTERPOLATED_VERBATIUM_STRING_START interpolated_verbatium_string_part* DOUBLE_QUOTE_INSIDE
    ;

interpolated_regular_string_part
    : interpolated_string_expression
    | DOUBLE_CURLY_INSIDE
    | REGULAR_CHAR_INSIDE
    | REGULAR_STRING_INSIDE
    ;

interpolated_verbatium_string_part
    : interpolated_string_expression
    | DOUBLE_CURLY_INSIDE
    | VERBATIUM_DOUBLE_QUOTE_INSIDE
    | VERBATIUM_INSIDE_STRING
    ;

interpolated_string_expression
    : expression (COMMA expression)* (COLON FORMAT_STRING+)?
    ;

//B.1.7 Keywords
keyword
    : ABSTRACT
    | AND   // C# 9 patterns
    | AS
    | BASE
    | BOOL
    | BREAK
    | BYTE
    | CASE
    | CATCH
    | CHAR
    | CHECKED
    | CLASS
    | CONST
    | CONTINUE
    | DECIMAL
    | DEFAULT
    | DELEGATE
    | DO
    | DOUBLE
    | ELSE
    | ENUM
    | EVENT
    | EXPLICIT
    | EXTERN
    | FALSE
    | FINALLY
    | FIXED
    | FLOAT
    | FOR
    | FOREACH
    | GOTO
    | IF
    | IMPLICIT
    | IN
    | INT
    | INTERFACE
    | INTERNAL
    | IS
    | LOCK
    | LONG
    | NAMESPACE
    | NEW
    | NOTNULL
    | NOT    // C# 9 patterns
    | NULL_
    | OBJECT
    | OPERATOR
    | OR     // C# 9 patterns
    | OUT
    | OVERRIDE
    | PARAMS
    | PRIVATE
    | PROTECTED
    | PUBLIC
    | READONLY
    | REF
    | RETURN
    | SBYTE
    | SEALED
    | SHORT
    | SIZEOF
    | STACKALLOC
    | STATIC
    | STRING
    | STRUCT
    | SWITCH
    | THIS
    | THROW
    | TRUE
    | TRY
    | TYPEOF
    | UINT
    | ULONG
    | UNCHECKED
    | UNMANAGED
    | UNSAFE
    | USHORT
    | USING
    | VIRTUAL
    | VOID
    | VOLATILE
    | WHILE
    ;

// -------------------- extra rules for modularization --------------------------------

class_definition
    : (RECORD CLASS? | CLASS) identifier type_parameter_list? class_base? type_parameter_constraints_clauses? class_body SEMICOLON?
    ;

struct_definition
    : (READONLY RECORD? | REF | RECORD)?  STRUCT identifier type_parameter_list? interface_base? type_parameter_constraints_clauses? struct_body SEMICOLON?
    ;

interface_definition
    : INTERFACE identifier variant_type_parameter_list? interface_base? type_parameter_constraints_clauses? class_body SEMICOLON?
    ;

enum_definition
    : ENUM identifier enum_base? enum_body SEMICOLON?
    ;

delegate_definition
    : DELEGATE return_type identifier variant_type_parameter_list? OPEN_PARENS formal_parameter_list? CLOSE_PARENS type_parameter_constraints_clauses?
        SEMICOLON
    ;

event_declaration
    : EVENT type_ (
        variable_declarators SEMICOLON
        | member_name OPEN_BRACE event_accessor_declarations CLOSE_BRACE
    )
    ;

field_declaration
    : variable_declarators SEMICOLON
    ;

property_declaration // Property initializer & lambda in properties C# 6
    : member_name (
        OPEN_BRACE accessor_declarations CLOSE_BRACE (ASSIGNMENT variable_initializer SEMICOLON)?
        | RIGHT_ARROW throwable_expression SEMICOLON
    )
    ;

constant_declaration
    : CONST type_ constant_declarators SEMICOLON
    ;

indexer_declaration // lamdas from C# 6
    : THIS OPEN_BRACKET formal_parameter_list CLOSE_BRACKET (
        OPEN_BRACE accessor_declarations CLOSE_BRACE
        | RIGHT_ARROW throwable_expression SEMICOLON
    )
    ;

destructor_definition
    : TILDE identifier OPEN_PARENS CLOSE_PARENS body
    ;

constructor_declaration
    : identifier OPEN_PARENS formal_parameter_list? CLOSE_PARENS constructor_initializer? body
    ;

method_declaration // lamdas from C# 6
    : method_member_name type_parameter_list? OPEN_PARENS formal_parameter_list? CLOSE_PARENS type_parameter_constraints_clauses? (
        method_body
        | RIGHT_ARROW throwable_expression SEMICOLON
    )
    ;

method_member_name
    : (identifier | identifier DOUBLE_COLON identifier) (type_argument_list? DOT identifier)*
    ;

operator_declaration // lamdas form C# 6
    : OPERATOR overloadable_operator OPEN_PARENS IN? arg_declaration (COMMA IN? arg_declaration)? CLOSE_PARENS (
        body
        | RIGHT_ARROW throwable_expression SEMICOLON
    )
    ;

arg_declaration
    : type_ identifier (ASSIGNMENT expression)?
    ;

method_invocation
    : OPEN_PARENS argument_list? CLOSE_PARENS
    ;

object_creation_expression
    : OPEN_PARENS argument_list? CLOSE_PARENS object_or_collection_initializer?
    ;

identifier
    : IDENTIFIER
    | ADD
    | ALIAS
    | ARGLIST
    | ASCENDING
    | ASYNC
    | AWAIT
    | BY
    | DESCENDING
    | DYNAMIC
    | EQUALS
    | FROM
    | GET
    | GROUP
    | INTO
    | JOIN
    | LET
    | NAMEOF
    | ON
    | ORDERBY
    | PARTIAL
    | REMOVE
    | SELECT
    | SET
    | UNMANAGED
    | VAR
    | WHEN
    | WHERE
    | YIELD
    ;