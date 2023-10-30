using FluentMigrator;

namespace Migrations
{
    [Migration(2)]
    public class CarMigration : Migration
    {
        public override void Up()
        {
            Create.Table("cars")
                .WithColumn("car_id").AsInt64().PrimaryKey().Identity()
                .WithColumn("user_id").AsInt64()
                .WithColumn("name").AsString()
                .WithColumn("model").AsString()
                .WithColumn("yearofrelease").AsString()
                .WithColumn("vincode").AsString().Unique();
            Insert.IntoTable("cars")
                .Row(new { user_id = "1", name = "Mersedes Benz", model = "AMG 500", yearofrelease = "2016", vincode = "Z624034908093" });
        }

        public override void Down()
        {
            Delete.Table("cars");
        }
    }
}