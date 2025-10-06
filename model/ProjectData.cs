using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public bool Equals(ProjectData other) //Реализует сравнения
        {
            if (Object.ReferenceEquals(other, null)) //Если тот объект с которым сравниваем это null
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other)) //Если объект один и тот же
            {
                return true;
            }
            return ProjectName == other.ProjectName;
        }

        public override int GetHashCode()
        {
            return ProjectName.GetHashCode();
        }

        public override string ToString()
        {
            return "projectName=" + ProjectName;
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return ProjectName.CompareTo(other.ProjectName);
        }

        public ProjectData(string projectName)
        {
            ProjectName = projectName;
        }

        public ProjectData() { } //10

        public string ProjectName { get; set; }
        public string Id { get; set; } //10
    }
}
