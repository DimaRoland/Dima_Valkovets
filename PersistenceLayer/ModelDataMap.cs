
using FluentNHibernate.Mapping;

namespace PersistenceLayer
{
    public class ModelDataMap : ClassMap<DataModel.DataModel>
    {
        public ModelDataMap()
        {
            Table("MyBlog");

            Id(x => x.id, "Id").GeneratedBy.Identity().UnsavedValue(0);

            Map(x => x.Description);
            Map(x => x.Posted);
            Map(x => x.Title);
        }
    }
}
