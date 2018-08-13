using Microsoft.EntityFrameworkCore.Migrations;

namespace imdb.Migrations
{
    public partial class MovieActorPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieActorID",
                table: "MovieActors",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieActorID",
                table: "MovieActors");
        }
    }
}
