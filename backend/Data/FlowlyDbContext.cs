using Microsoft.EntityFrameworkCore;
using Flowly.Api.Models;

namespace Flowly.Api.Data;

public class FlowlyDbContext : DbContext
{
    public FlowlyDbContext(DbContextOptions<FlowlyDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Board> Boards => Set<Board>();
    public DbSet<Column> Columns => Set<Column>();
    public DbSet<Card> Cards => Set<Card>();
    public DbSet<Attachment> Attachments => Set<Attachment>();
    public DbSet<Collaborator> Collaborators => Set<Collaborator>();
    public DbSet<GuestSession> GuestSessions => Set<GuestSession>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<Board>().HasOne(b => b.Owner).WithMany(u => u.Boards).HasForeignKey(b => b.OwnerId).HasPrincipalKey(u => u.UserId);
        modelBuilder.Entity<Collaborator>().HasKey(c => c.CollaboratorId);

        // Board -> Collaborators
        modelBuilder.Entity<Board>()
            .HasMany(b => b.Collaborators)
            .WithOne(c => c.Board)
            .HasForeignKey(c => c.BoardId);

        // Collaborator -> User
        modelBuilder.Entity<Collaborator>()
            .HasOne(c => c.User)
            .WithMany(u => u.Collaborations)
            .HasForeignKey(c => c.UserId);

        modelBuilder.Entity<GuestSession>()
            .HasOne(gs => gs.User)
            .WithMany(u => u.GuestSessions)
            .HasForeignKey(gs => gs.UserId);
    }
}
