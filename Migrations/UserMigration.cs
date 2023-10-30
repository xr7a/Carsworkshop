using FluentMigrator;

namespace Migrations
{
    [Migration(0)]
    public class UserMigration : Migration
    {
        public override void Up()
        {
            Create.Table("users")
                .WithColumn("user_id").AsInt64().PrimaryKey().Identity()
                .WithColumn("first_name").AsString()
                .WithColumn("last_name").AsString()
                .WithColumn("email").AsString().Unique()
                .WithColumn("phonenumber").AsString().Unique()
                .WithColumn("adress").AsString();
            Insert.IntoTable("users")
                .Row(new {first_name = "Ivan", last_name = "Churka", email = "sfkljsf@mail.ru", phonenumber = "+834938244", adress = "Moscow, street Orlova"});
        }

        public override void Down()
        {
            Delete.Table("users");
        }
    }
}