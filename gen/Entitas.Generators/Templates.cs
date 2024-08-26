using System;
using System.Linq;

namespace Entitas.Generators
{
    public static class Templates
    {
        public static string GeneratedPath(string hintName)
        {
            return $"{hintName}.g.cs";
        }

        public static string GeneratedFileHeader(string generatorSource)
        {
            return $$"""
                //------------------------------------------------------------------------------
                // <auto-generated>
                //     This code was generated by
                //     {{generatorSource}}
                //
                //     Changes to this file may cause incorrect behavior and will be lost if
                //     the code is regenerated.
                // </auto-generated>
                //------------------------------------------------------------------------------

                """;
        }

        public static string FileNameHint(string? @namespace, string name)
        {
            return !string.IsNullOrEmpty(@namespace)
                ? $"{@namespace}.{name}.g.cs"
                : $"{name}.g.cs";
        }
        public static string CombinedNamespace(string? @namespace, string suffix)
        {
            return !string.IsNullOrEmpty(@namespace)
                ? $"{@namespace}.{suffix}"
                : suffix;
        }

        public static string NamespaceDeclaration(string? @namespace, string content)
        {
            return !string.IsNullOrEmpty(@namespace)
                ? $"namespace {@namespace}\n{{\n{content}}}\n"
                : content;
        }
        public static string NamespaceClassifier(this string? @namespace)
        {
            return !string.IsNullOrEmpty(@namespace)
                ? $"{@namespace}."
                : string.Empty;
        }

        public static string RemoveSuffix(this string str, string suffix)
        {
            return str.EndsWith(suffix, StringComparison.Ordinal)
                ? str.Substring(0, str.Length - suffix.Length)
                : str;
        }

        public static string ContextPrefix(string context)
        {
            return context.RemoveSuffix("Context");
        }

        public static string ContextAware(string contextPrefix)
        {
            return contextPrefix.Replace(".", string.Empty);
        }

        public static string ComponentMethodParams(ComponentDeclaration component) =>
            string.Join(", ", component.Members.Select(static member => $"{member.Type} {member.ValidLowerFirstName}"));

        public static string ComponentMethodArgs(ComponentDeclaration component) =>
            string.Join(", ", component.Members.Select(static member => $"{member.ValidLowerFirstName}"));

        public static string ComponentValueMethodArgs(ComponentDeclaration component) =>
            string.Join(", ", component.Members.Select(static member => $"component.{member.Name}"));

        public static string ComponentValueAssignments(ComponentDeclaration component) =>
            string.Join("\n", component.Members.Select(static member => $"        component.{member.Name} = {member.ValidLowerFirstName};"));
    }
}
