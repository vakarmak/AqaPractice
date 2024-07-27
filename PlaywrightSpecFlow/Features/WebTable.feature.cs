﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace PlaywrightSpecFlow.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("WebTableTest")]
    [NUnit.Framework.CategoryAttribute("ReusesFeatureDriver")]
    [NUnit.Framework.CategoryAttribute("WebPageLogin")]
    public partial class WebTableTestFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "ReusesFeatureDriver",
                "WebPageLogin"};
        
#line 1 "WebTable.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "WebTableTest", "  As a User i want to add new item to web table,\r\n  so that i can see the new ite" +
                    "m in the table\r\n  and i can delete and edit item.", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("I see item in the table")]
        [NUnit.Framework.TestCaseAttribute("Cierra", "Vega", null)]
        [NUnit.Framework.TestCaseAttribute("Alden", "Cantrell", null)]
        [NUnit.Framework.TestCaseAttribute("Kierra", "Gentry", null)]
        public void ISeeItemInTheTable(string firstName, string lastName, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("FirstName", firstName);
            argumentsOfScenario.Add("LastName", lastName);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I see item in the table", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 10
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 11
 testRunner.Given("I am on DemoQA WebTable Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 12
 testRunner.When("I see the WebTable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 13
 testRunner.Then(string.Format("I see FirstName \"{0}\" in a table", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 14
 testRunner.Then(string.Format("I see LastName \"{0}\" in a table", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("I add item to the table")]
        [NUnit.Framework.TestCaseAttribute("Ryan", "Blevins", "cooperjoshua@hotmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Derrick", "Sandoval", "williamhenderson@hotmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Kimberly", "Douglas", "susan34@yahoo.com", null)]
        [NUnit.Framework.TestCaseAttribute("Michael", "Clark", "jenniferfinley@gonzalez.com", null)]
        [NUnit.Framework.TestCaseAttribute("Diana", "Ray", "susan38@long.com", null)]
        [NUnit.Framework.TestCaseAttribute("Christopher", "White", "fhobbs@brown-ortega.com", null)]
        [NUnit.Framework.TestCaseAttribute("Tanya", "Larson", "qfigueroa@yahoo.com", null)]
        [NUnit.Framework.TestCaseAttribute("Donald", "Johnston", "bennettanita@gmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Samantha", "Williams", "michael19@hotmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Keith", "Soto", "edwarddorsey@george.com", null)]
        [NUnit.Framework.TestCaseAttribute("Aaron", "Stewart", "aaronstewart@hotmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Jessica", "Powell", "jessicapowell@yahoo.com", null)]
        [NUnit.Framework.TestCaseAttribute("Brian", "Scott", "brianscott@gmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Lisa", "Edwards", "lisaedwards@hotmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Eric", "Russell", "ericrussell@live.com", null)]
        [NUnit.Framework.TestCaseAttribute("Laura", "Perry", "lauraperry@gmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Mark", "Watson", "markwatson@outlook.com", null)]
        [NUnit.Framework.TestCaseAttribute("Nancy", "Baker", "nancybaker@hotmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Frank", "Murphy", "frankmurphy@gmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Gloria", "Bryant", "gloriabryant@yahoo.com", null)]
        [NUnit.Framework.TestCaseAttribute("George", "Evans", "georgeevans@outlook.com", null)]
        [NUnit.Framework.TestCaseAttribute("Linda", "Howard", "lindahoward@hotmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Steven", "Ward", "stevenward@gmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Amy", "Kelly", "amy.kelly@yahoo.com", null)]
        [NUnit.Framework.TestCaseAttribute("Justin", "Flores", "justinflores@live.com", null)]
        [NUnit.Framework.TestCaseAttribute("Karen", "Morales", "karenmorales@gmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Paul", "Cooper", "paulcooper@hotmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Laura", "Ward", "lauraward@outlook.com", null)]
        [NUnit.Framework.TestCaseAttribute("Daniel", "Hughes", "danielhughes@gmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Michelle", "Foster", "michellefoster@yahoo.com", null)]
        [NUnit.Framework.TestCaseAttribute("Kevin", "Rivera", "kevinrivera@live.com", null)]
        [NUnit.Framework.TestCaseAttribute("Angela", "Simmons", "angelasimmons@gmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Jason", "Butler", "jasonbutler@hotmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Melissa", "Gray", "melissagray@yahoo.com", null)]
        [NUnit.Framework.TestCaseAttribute("Charles", "Cooper", "charlescooper@outlook.com", null)]
        [NUnit.Framework.TestCaseAttribute("Amanda", "Stewart", "amandastewart@gmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Edward", "Sanders", "edwardsanders@yahoo.com", null)]
        [NUnit.Framework.TestCaseAttribute("Emily", "Brooks", "emilybrooks@live.com", null)]
        [NUnit.Framework.TestCaseAttribute("Joshua", "Bell", "joshuabell@gmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Sarah", "Gonzales", "sarahgonzales@yahoo.com", null)]
        [NUnit.Framework.TestCaseAttribute("Daniel", "Ramirez", "danielramirez@hotmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Patricia", "Alexander", "patricia.alexander@gmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Matthew", "Hamilton", "matthewhamilton@outlook.com", null)]
        [NUnit.Framework.TestCaseAttribute("Barbara", "Graham", "barbara.graham@yahoo.com", null)]
        [NUnit.Framework.TestCaseAttribute("David", "Patterson", "davidpatterson@live.com", null)]
        [NUnit.Framework.TestCaseAttribute("Jennifer", "Cox", "jennifercox@gmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("Richard", "Wallace", "richardwallace@yahoo.com", null)]
        [NUnit.Framework.TestCaseAttribute("Stephanie", "Carter", "stephaniecarter@outlook.com", null)]
        [NUnit.Framework.TestCaseAttribute("Brian", "Woods", "brianwoods@hotmail.com", null)]
        public void IAddItemToTheTable(string firstName, string lastName, string email, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("FirstName", firstName);
            argumentsOfScenario.Add("LastName", lastName);
            argumentsOfScenario.Add("Email", email);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I add item to the table", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 21
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 22
 testRunner.Given("I am on DemoQA WebTable Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 23
 testRunner.When("I see the WebTable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 24
 testRunner.And(string.Format("I add the FisrtName \"{0}\" and LastName \"{1}\" and Email \"{2}\" to the table", firstName, lastName, email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 25
 testRunner.Then(string.Format("I should see the FirstName \"{0}\" and LastName \"{1}\" and \"{2}\" in the table", firstName, lastName, email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
