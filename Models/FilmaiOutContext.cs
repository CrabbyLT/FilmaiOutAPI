using FilmaiOutAPI.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FilmaiOutAPI
{
    public partial class FilmaiOutContext : DbContext
    {
        public FilmaiOutContext()
        {
        }

        public FilmaiOutContext(DbContextOptions<FilmaiOutContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentReport> CommentReports { get; set; }
        public virtual DbSet<ListMovie> ListMovies { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieList> MovieLists { get; set; }
        public virtual DbSet<MovieReport> MovieReports { get; set; }
        public virtual DbSet<MovieReview> MovieReviews { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Subtitle> Subtitles { get; set; }
        public virtual DbSet<SubtitleList> SubtitleLists { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Disabled).HasColumnName("disabled");

                entity.Property(e => e.Dislikes).HasColumnName("dislikes");

                entity.Property(e => e.FkPostsId).HasColumnName("fk_posts_id");

                entity.Property(e => e.FkUsersName).HasColumnName("fk_users_name");

                entity.Property(e => e.LastEditedAt)
                    .HasColumnName("last_edited_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Likes).HasColumnName("likes");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");

                entity.HasOne(d => d.FkPosts)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.FkPostsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("comments_fk_posts_id_fkey");

                entity.HasOne(d => d.FkUsersNameNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.FkUsersName)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("comments_fk_users_name_fkey");
            });

            modelBuilder.Entity<CommentReport>(entity =>
            {
                entity.ToTable("comment_reports");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accepted).HasColumnName("accepted");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.FkCommentsId).HasColumnName("fk_comments_id");

                entity.Property(e => e.Reviewed).HasColumnName("reviewed");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");

                entity.HasOne(d => d.FkComments)
                    .WithMany(p => p.CommentReports)
                    .HasForeignKey(d => d.FkCommentsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("comment_reports_fk_comments_id_fkey");
            });

            modelBuilder.Entity<ListMovie>(entity =>
            {
                entity.ToTable("list_movies");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkMovieLists).HasColumnName("fk_movie_lists");

                entity.Property(e => e.FkMovies).HasColumnName("fk_movies");

                entity.HasOne(d => d.FkMovieListsNavigation)
                    .WithMany(p => p.ListMovies)
                    .HasForeignKey(d => d.FkMovieLists)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("list_movies_fk_movie_lists_fkey");

                entity.HasOne(d => d.FkMoviesNavigation)
                    .WithMany(p => p.ListMovies)
                    .HasForeignKey(d => d.FkMovies)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("list_movies_fk_movies_fkey");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movies");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Language)
                    .HasMaxLength(20)
                    .HasColumnName("language")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MovieList>(entity =>
            {
                entity.ToTable("movie_lists");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Dislikes).HasColumnName("dislikes");

                entity.Property(e => e.FkUsersName).HasColumnName("fk_users_name");

                entity.Property(e => e.Likes).HasColumnName("likes");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");

                entity.HasOne(d => d.FkUsersNameNavigation)
                    .WithMany(p => p.MovieLists)
                    .HasForeignKey(d => d.FkUsersName)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("movie_lists_fk_users_name_fkey");
            });

            modelBuilder.Entity<MovieReport>(entity =>
            {
                entity.ToTable("movie_reports");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AverageScore)
                    .HasPrecision(4, 2)
                    .HasColumnName("average_score");

                entity.Property(e => e.FkMovies).HasColumnName("fk_movies");

                entity.Property(e => e.FkUsers).HasColumnName("fk_users");

                entity.Property(e => e.GeneratedAt)
                    .HasColumnName("generated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.TotalMovieLists).HasColumnName("total_movie_lists");

                entity.Property(e => e.Views).HasColumnName("views");

                entity.HasOne(d => d.FkMoviesNavigation)
                    .WithMany(p => p.MovieReports)
                    .HasForeignKey(d => d.FkMovies)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("movie_reports_fk_movies_fkey");

                entity.HasOne(d => d.FkUsersNavigation)
                    .WithMany(p => p.MovieReports)
                    .HasForeignKey(d => d.FkUsers)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("movie_reports_fk_users_fkey");
            });

            modelBuilder.Entity<MovieReview>(entity =>
            {
                entity.ToTable("movie_reviews");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Dislikes).HasColumnName("dislikes");

                entity.Property(e => e.FkMovies).HasColumnName("fk_movies");

                entity.Property(e => e.FkUsers).HasColumnName("fk_users");

                entity.Property(e => e.LastEditedAt)
                    .HasColumnName("last_edited_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Likes).HasColumnName("likes");

                entity.Property(e => e.Score)
                    .HasPrecision(2)
                    .HasColumnName("score");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");

                entity.HasOne(d => d.FkMoviesNavigation)
                    .WithMany(p => p.MovieReviews)
                    .HasForeignKey(d => d.FkMovies)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("movie_reviews_fk_movies_fkey");

                entity.HasOne(d => d.FkUsersNavigation)
                    .WithMany(p => p.MovieReviews)
                    .HasForeignKey(d => d.FkUsers)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("movie_reviews_fk_users_fkey");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("posts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Dislikes).HasColumnName("dislikes");

                entity.Property(e => e.FkUsersName).HasColumnName("fk_users_name");

                entity.Property(e => e.LastEditedAt)
                    .HasColumnName("last_edited_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Likes).HasColumnName("likes");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");

                entity.Property(e => e.Views).HasColumnName("views");

                entity.HasOne(d => d.FkUsersNameNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.FkUsersName)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("posts_fk_users_name_fkey");
            });

            modelBuilder.Entity<Subtitle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("subtitle");

                entity.Property(e => e.FinishAt).HasColumnName("finish_at");

                entity.Property(e => e.FkSubtitleLists).HasColumnName("fk_subtitle_lists");

                entity.Property(e => e.StartAt).HasColumnName("start_at");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");

                entity.HasOne(d => d.FkSubtitleListsNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FkSubtitleLists)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("subtitle_fk_subtitle_lists_fkey");
            });

            modelBuilder.Entity<SubtitleList>(entity =>
            {
                entity.ToTable("subtitle_lists");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkMovies).HasColumnName("fk_movies");

                entity.Property(e => e.FkUsers).HasColumnName("fk_users");

                entity.Property(e => e.Language)
                    .HasMaxLength(20)
                    .HasColumnName("language")
                    .IsFixedLength(true);

                entity.HasOne(d => d.FkMoviesNavigation)
                    .WithMany(p => p.SubtitleLists)
                    .HasForeignKey(d => d.FkMovies)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("subtitle_lists_fk_movies_fkey");

                entity.HasOne(d => d.FkUsersNavigation)
                    .WithMany(p => p.SubtitleLists)
                    .HasForeignKey(d => d.FkUsers)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("subtitle_lists_fk_users_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("users_pkey");

                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "users_email_key")
                    .IsUnique();

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Administrator).HasColumnName("administrator");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.LastLoginAt).HasColumnName("last_login_at");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasColumnName("password_hash");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
