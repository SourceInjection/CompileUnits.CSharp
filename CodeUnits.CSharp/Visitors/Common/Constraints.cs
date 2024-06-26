﻿using System.Collections.Generic;
using System.Linq;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors.Common
{
    internal static class Constraints
    {
        public static List<ConstraintDefinition> FromContext(
            Type_parameter_constraints_clausesContext context, 
            IEnumerable<GenericTypeArgumentDefinition> genericTypeArguments)
        {
            if (context is null)
                return new List<ConstraintDefinition>();

            return context.type_parameter_constraints_clause()
                .Select(c => new ConstraintDefinition(
                        genericTypeArguments.FirstOrDefault(ta => ta.Name == c.identifier().GetText()),
                        GetClauses(c.type_parameter_constraints())))
                .ToList();
        }

        private static List<ConstraintClause> GetClauses(Type_parameter_constraintsContext context)
        {
            var clauses = new List<ConstraintClause>();
            if (context is null)
                return clauses;

            var primary = GetPrimaryConstraint(context.primary_constraint());
            if (primary != null)
                clauses.Add(primary);

            clauses.AddRange(GetSecondaryConstraints(context.secondary_constraints()));

            if (context.constructor_constraint() != null)
                clauses.Add(new ConstraintClause(ConstraintKind.Constructor));

            return clauses;
        }

        private static ConstraintClause GetPrimaryConstraint(Primary_constraintContext context)
        {
            if (context is null)
                return null;

            if (context.class_type() != null)
                return new ConstraintClause(ConstraintKind.OfType, new TypeUsage(context.class_type()));
            else if (context.STRUCT() != null)
                return new ConstraintClause(ConstraintKind.Struct);
            else if (context.UNMANAGED() != null)
                return new ConstraintClause(ConstraintKind.Unmanaged);
            else if(context.NOTNULL() != null)
                return new ConstraintClause(ConstraintKind.NotNull);
            else if (context.CLASS() != null)
            {
                if (context.CLASS().GetText().EndsWith("?"))
                    return new ConstraintClause(ConstraintKind.ClassNullable);
                else return new ConstraintClause(ConstraintKind.Class);
            }
            return null;
        }

        private static IEnumerable<ConstraintClause> GetSecondaryConstraints(Secondary_constraintsContext context)
        {
            if (context is null)
                yield break;

            foreach (var c in context.namespace_or_type_name())
                yield return new ConstraintClause(ConstraintKind.OfType, new TypeUsage(c));
        }
    }
}
