namespace TeamBuilder.Data.Configurations
{
    using Models;
    using System;
    using System.Data.Entity.ModelConfiguration;

    public class InvitationConfiguration : EntityTypeConfiguration<Invitation>
    {
        public InvitationConfiguration()
        {
            this.HasRequired(i => i.Team)
                .WithMany(t => t.Invitations);

            this.HasRequired(i => i.InvitedUser)
                .WithMany(u => u.ReceivedInvitations);

        }
    }
}
