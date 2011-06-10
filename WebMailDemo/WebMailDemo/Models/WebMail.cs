using System;
using System.Data.Entity;

namespace WebMailDemo.Models
{
    public class MailItem
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }

        // 1:many relation - MailItem belongs to MailFolder
        public int MailFolderId { get; set; }
        public virtual MailFolder MailFolder { get; set; }
    }

    public class MailFolder
    {
        public int MailFolderId { get; set; }
        public string Name { get; set; }
    }

    public class MailDbContext : DbContext
    {
        public DbSet<MailFolder> MailFolders { get; set; }
        public DbSet<MailItem> MailItems { get; set; }
    }
}