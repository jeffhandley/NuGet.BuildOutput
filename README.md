NuGet.BuildOutput
======================
When installed into a project as a NuGet package, new MSBuild properties
will be generated during build that provide information about the NuGet
packages installed into the project.  Other packages or utilities can then
consume this build output.