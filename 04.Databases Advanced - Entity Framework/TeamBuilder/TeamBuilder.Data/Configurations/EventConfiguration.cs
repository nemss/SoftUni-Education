namespace TeamBuilder.Data.Configurations
{
    using Models;
    using System;
    using System.Data.Entity.ModelConfiguration;

    public class EventConfiguration : EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            this.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(e => e.Description)
                .HasMaxLength(250);

            this.HasRequired(e => e.Creator)
                .WithMany(e => e.CreatedEvents);

            this.HasMany(e => e.ParticipatingTeams)
                .WithMany(t => t.ParticipatingEvents)
                .Map(
                        ca =>
                    {
                        ca.MapLeftKey("EventId");
                        ca.MapLeftKey("TeamId");
                    });
        }
    }
}
