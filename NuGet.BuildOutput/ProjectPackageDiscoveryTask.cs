using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Build.Framework;

namespace NuGet.BuildOutput
{
    public class ProjectPackageDiscoveryTask : Microsoft.Build.Utilities.Task
    {
        public override bool Execute()
        {
            var packagesConfig = Path.Combine(this.MSBuildProjectDirectory, "packages.config");

            var packagesFolder = Path.Combine(this.SolutionDir, "packages");
            var packagesRepo = new SharedPackageRepository(packagesFolder);
            var projectPackages = new PackageReferenceRepository(new PhysicalFileSystem(this.MSBuildProjectDirectory), packagesRepo);

            projectPackages.GetPackages()
                .Select(p => packagesRepo.PathResolver.GetPackageDirectory(p)).ToList()
                .ForEach(p => _packageFolders.Add(Path.Combine(packagesFolder, p)));

            return true;
        }

        private IList<string> _packageFolders = new List<string>();

        public string MSBuildProjectDirectory { get; set; }
        public string SolutionDir { get; set; }

        [Output]
        public string[] PackageFolders
        {
            get
            {
                return _packageFolders.ToArray();
            }
        }
    }
}
