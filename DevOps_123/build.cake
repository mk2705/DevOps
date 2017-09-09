#tool "nuget:?package=NUnit.Runners&version=2.6.4"
//#tools "nuget:?package=OpenCover"

var target = Argument("target", "Default");

Task("Default")
  .IsDependentOn("Clean")
  .IsDependentOn("Restore")
  .IsDependentOn("Build")
  .IsDependentOn("UnitTesting");
//  .IsDependentOn("CodeCoverage");
  
Task("Clean")  
    .Does(() =>
{
	CleanDirectory("./NAGP_4183_Console/bin/Debug");
	CleanDirectory("./NAGP_4183_UnitTesting/bin/Debug");
	CleanDirectory("./NAGP_4183_IntegrationTesting/bin/Debug");
});


Task("Restore")  
    .Does(() =>
{
    NuGetRestore("./DevOps_123.sln");
});

Task("Build")
  .Does(() =>
{
  MSBuild("./DevOps_123.sln");
});

Task("UnitTesting")
    .Does(() =>
{
  NUnit("./NAGP_4183_UnitTesting/bin/Debug/NAGP_4183_UnitTesting.dll");
});

/*
Task("CodeCoverage")
    .Does(tool =>
    {
        tool.NUnit("./NAGP_4183_UnitTesting/bin/Debug/NAGP_4183_UnitTesting.dll");
    },
    new FilePath("./result.xml"),
    new OpenCoverSettings()
);
*/

RunTarget(target);