using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TAP.Core.Entities;

namespace TAP.DataAccess.SqlServer.Mappings
{
    class CommentMapping: IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment")
                .HasKey(_ => _.Id);
            builder.Property(_ => _.Id).IsRequired();
            builder.Property(_ => _.Author).HasColumnName("Author");
            builder.Property(_ => _.Content).HasColumnName("Content");
            builder.Property(_ => _.AuthorId).HasColumnName("AuthorId");
            builder.Property(_ => _.BlogId).HasColumnName("BlogId");
        }
    }
}
