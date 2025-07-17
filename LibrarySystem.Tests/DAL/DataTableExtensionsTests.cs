using System.Data;
using LibrarySystem.DAL.Helpers;
namespace LibrarySystem.Tests.DAL
{
    public class DataTableExtensionsTests
    {
        public class SampleEntity
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime CreatedDate { get; set; }
        }

        [Fact]
        public void ToEntity_Should_Map_Valid_DataRow_To_Entity()
        {
            // Arrange
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("CreatedDate", typeof(DateTime));

            var row = table.NewRow();
            row["Id"] = 1;
            row["Name"] = "Test Entity";
            row["CreatedDate"] = new DateTime(2023, 1, 1);
            table.Rows.Add(row);

            // Act
            var entity = table.ToList<SampleEntity>().FirstOrDefault();

            // Assert
            Assert.Equal(1, entity.Id);
            Assert.Equal("Test Entity", entity.Name);
            Assert.Equal(new DateTime(2023, 1, 1), entity.CreatedDate);
        }

        [Fact]
        public void ToEntity_Should_Return_Default_Instance_When_Row_Is_Null()
        {
            // Arrange
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("CreatedDate", typeof(DateTime));

            var row = table.NewRow();
            table.Rows.Add(row);

            // Act
            var entity = table.ToList<SampleEntity>().FirstOrDefault();

            // Assert
            Assert.NotNull(entity);
            Assert.Equal(0, entity.Id);
            Assert.Null(entity.Name);
            Assert.Equal(default, entity.CreatedDate);
        }

        [Fact]
        public void ToEntity_Should_Ignore_Properties_That_Do_Not_Match_Columns()
        {
            // Arrange
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));

            var row = table.NewRow();
            row["Id"] = 42;
            table.Rows.Add(row);

            // Act
            var entity = table.ToList<SampleEntity>().FirstOrDefault();

            // Assert
            Assert.Equal(42, entity.Id);
            Assert.Null(entity.Name); // Should remain default because column doesn't exist
            Assert.Equal(default, entity.CreatedDate);
        }

        [Fact]
        public void ToEntity_Should_Not_Throw_When_DbNull_Value_Is_Present()
        {
            // Arrange
            var table = new DataTable();
            table.Columns.Add("Name", typeof(string));

            var row = table.NewRow();
            row["Name"] = DBNull.Value;
            table.Rows.Add(row);

            // Act
            var entity = table.ToList<SampleEntity>().FirstOrDefault();

            // Assert
            Assert.Null(entity.Name); // Should handle DBNull gracefully
        }
    }
}
