using TaskManager.Data.Models;

namespace TaskManager.Shared
{
    public class ProjectSelectionService
    {
        public Project? SelectedProject { get; private set; }
        public event Action? OnProjectChanged;

        public void SetProject(Project? project)
        {
            SelectedProject = project;
            OnProjectChanged?.Invoke();
        }
    }
}
