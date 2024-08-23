# CompileUnits.CSharp

A library to which is designed to analyze generated code with source generators.

## Usage

The main entry point is CompileUnits.CSharp.CompileUnit which provides several methods to get your semi structured info of the source code within a file.

## Known Issues and restrictions

- Does not support unmanaged code
- Does not support compiler directives now
- Right shift operator is not a terminal symbol and is captured as two greater than symbols ('>' '>')
