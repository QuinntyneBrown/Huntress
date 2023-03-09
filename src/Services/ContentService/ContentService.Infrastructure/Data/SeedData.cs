using ContentService.Core.AggregateModel.JsonPropertyModelAggregate;
using ContentService.Core.AggregateModel.JsonSchemaModelAggregate;
using Microsoft.EntityFrameworkCore;
using Security;

namespace ContentService.Infrastructure.Data;

public static class SeedData
{
    public static void Seed(this ContentServiceDbContext context)
    {
        var defualtJsonSchemaModel = context.JsonSchemaModels.Include(x => x.Properties)
            .FirstOrDefault(x => x.Name == "Default");

        if(defualtJsonSchemaModel == null)
        {
            defualtJsonSchemaModel = new JsonSchemaModel("Default");

            defualtJsonSchemaModel.Properties.Add(new JsonPropertyModel("Name"));

            context.JsonSchemaModels.Add(defualtJsonSchemaModel);

            context.SaveChanges();
        }
    }
}
