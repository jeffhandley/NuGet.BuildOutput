NuGet.BuildOutput
======================
When installed into a project as a NuGet package, new MSBuild properties
will be generated during build that provide information about the NuGet
packages installed into the project.  Other packages or utilities can then
consume this build output.

Here's how it works:

  1. The NuGet.BuildOutput package contains the following:
      1. *NuGet.BuildOutput.targets* - a targets file that adds a new MSBuild task into the build
      1. *NuGet.BuildOutput.dll* - the dll that contains the ProjectPackageDiscoveryTask, which gathers the list of packages referenced by the project being built (including itself).  The installation folders of those packages are then output as a PackageFolders MSBuild Item
      1. *NuGet.Core.dll* - NuGet's core API, which is required by NuGet.BuildOutput.dll
      1. *install.ps1* - the installation script that adds NuGet.BuildOutput.targets into the project file
  1. Once NuGet.BuildOutput is installed into a project, the MSBuild item of PackageFolders will be populated after the build
  1. Other tooling could consume this MSBuild item and perform additional logic based on the packages installed in the project