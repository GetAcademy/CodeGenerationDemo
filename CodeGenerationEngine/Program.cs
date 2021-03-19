using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CodeGenerationEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText("metadata.json");
            var metadata = JsonSerializer.Deserialize<Metadata>(json);
            var baseFolder = @"C:\Users\Terje\source\repos\CodeGenerationDemo\CodeGenerationDemo\Generated\";

            foreach (var entity in metadata.entities)
            {
                var filename = baseFolder + entity.name + ".cs";

                var csCode = entity.template == "EntityX"
                    ? GetCsCodeX(entity)
                    : GetCsCodeY(entity);
                File.WriteAllText(filename, csCode);
            }
        }

        private static string GetCsCodeX(Entity entity)
        {
            var csCode = @$"
namespace CodeGenerationDemo {{
    partial class {entity.name} : BaseEntity {{

    }}
}}
                ";
            return csCode;
        }

        private static string GetCsCodeY(Entity entity)
        {
            var csCode = @$"
using CodeGenerationDemo;

public partial class {entity.name} : BaseEntity {{

}}
                ";
            return csCode;
        }
    }
}
