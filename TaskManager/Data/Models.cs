using System.Collections.Generic;

namespace TaskManager.Data.Models
{
    public class Workspace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Folder> Folders { get; set; }
    }

    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorkspaceId { get; set; }
        public Workspace Workspace { get; set; }
        public ICollection<Project> Projects { get; set; }
    }

    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FolderId { get; set; }
        public Folder Folder { get; set; }
        public ICollection<Section> Sections { get; set; }
    }

    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<TaskItem> Tasks { get; set; }
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Urgency Urgency { get; set; }
        public int? SectionId { get; set; }
        public Section Section { get; set; }
        public int? ParentTaskId { get; set; }
        public TaskItem ParentTask { get; set; }
        public ICollection<TaskItem> Subtasks { get; set; }
        public ICollection<TaskTag> TaskTags { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TaskTag> TaskTags { get; set; }
    }

    public class TaskTag
    {
        public int TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }

    public enum Priority
    {
        Baja,
        Media,
        Alta
    }

    public enum Urgency
    {
        Baja,
        Media,
        Alta
    }
}
