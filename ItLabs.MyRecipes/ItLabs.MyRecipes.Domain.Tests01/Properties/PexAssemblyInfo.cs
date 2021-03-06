// <copyright file="PexAssemblyInfo.cs">Copyright ©  2016</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("ItLabs.MyRecipes.Domain")]
[assembly: PexInstrumentAssembly("AutoMapper")]
[assembly: PexInstrumentAssembly("Autofac.Integration.WebApi")]
[assembly: PexInstrumentAssembly("System.Web.Mvc")]
[assembly: PexInstrumentAssembly("Autofac.Integration.Mvc")]
[assembly: PexInstrumentAssembly("Autofac")]
[assembly: PexInstrumentAssembly("ItLabs.MyRecipes.Core")]
[assembly: PexInstrumentAssembly("FluentValidation")]
[assembly: PexInstrumentAssembly("ItLabs.MyRecipes.Data")]
[assembly: PexInstrumentAssembly("System.Core")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "AutoMapper")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Autofac.Integration.WebApi")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Web.Mvc")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Autofac.Integration.Mvc")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Autofac")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "ItLabs.MyRecipes.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "FluentValidation")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "ItLabs.MyRecipes.Data")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Core")]

