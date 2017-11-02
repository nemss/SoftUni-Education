namespace TeamBuilder.Data.Configurations
{
    using Models;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration;

    public class TeamConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamConfiguration()
        {
            this.Property(t => t.Name)
              .HasColumnAnnotation(IndexAnnotation.AnnotationName,
              new IndexAnnotation(
                  new IndexAttribute("IX_Team_Name", 1) { IsUnique = true }))
                  .HasMaxLength(25)
                  .IsRequired();

            this.Property(t => t.Description)
                .HasMaxLength(32);

            this.Property(t => t.Acronym)
                .IsRequired()
                .HasMaxLength(3)
                .IsFixedLength();

            this.HasMany(e => e.Invitations)
                .WithRequired(t => t.Team);

            this.HasRequired(t => t.Creator)
                .WithMany(t => t.CreatedTeams);
           
        }
    }
}
