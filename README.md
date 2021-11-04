# xunit unit test result

Xunit test logger can generate xml reports in the xunit v2 format (https://xunit.net/docs/format-xml-v2).
MS Test Framework support TRX format result(.trx), For generate xml file result, you can add a reference to the Xunit Logger nuget package in test project
Use the following command line in tests

Package: XunitXml.TestLogger  [3.0.70]

```
dotnet test --logger:xunit
```
Test results are generated in the TestResults directory relative to the test.csproj
But not html report!

The tool support to generate html report from xml file.

# xunit-xml2html tool
xunit v2 format test result (.xml) convert to html report

