#pragma checksum "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9796dddb60db05bc835ddd26753216138d61131"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Leaderboard_Index), @"mvc.1.0.view", @"/Views/Leaderboard/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\_ViewImports.cshtml"
using ImperiumSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\_ViewImports.cshtml"
using ImperiumSite.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
using ImperiumSite.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9796dddb60db05bc835ddd26753216138d61131", @"/Views/Leaderboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"983a24ac416de16674ab9b40e9f3afd25f5bb91d", @"/Views/_ViewImports.cshtml")]
    public class Views_Leaderboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ImperiumSite.Models.LeaderboardBaseViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/default-avatar.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("playerImage"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("avatar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("90"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
  
    ViewData["Title"] = "Index";

    Manager m = new Manager();

    var myLeaderboard = m.LeaderboardGetByPlayerId(int.Parse(User.Identity.Name));
    myLeaderboard.Player = m.PlayerGetById(myLeaderboard.PLAYER_ID);

    var tmp = Model.ToArray();
    var myRank = 0;

    for (int cnt = 0; cnt < tmp.Length; cnt++)
    {
        if (tmp[cnt].LEADERBOARD_ID == myLeaderboard.LEADERBOARD_ID)
        {
            myRank = cnt + 1;
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a9796dddb60db05bc835ddd26753216138d611316330", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<h1 class=""text-center"" style=""font-family:Game_Time"">My Leaderboard Rank</h1>

<div class=""container"" style=""background-color:rgba(230, 215, 218, 0.90); font-size:16px; border-color:black; border-style: solid; border-width:thick; border-radius:5px"">
    <div class=""row"">
        <div class=""col-md-2"" style=""border-right: 1px solid black;"">
            <br />
            <b>Rank: ");
#nullable restore
#line 32 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
                Write(myRank);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n        </div>\r\n        <div class=\"col-md-6\" style=\"border-right: 1px solid black;\">\r\n");
#nullable restore
#line 35 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
             if (myLeaderboard.Player.PLAYER_AVATAR.Length != 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <img");
            BeginWriteAttribute("src", " src=\"", 1207, "\"", 1244, 2);
            WriteAttributeValue("", 1213, "/photo/", 1213, 7, true);
#nullable restore
#line 37 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
WriteAttributeValue("", 1220, myLeaderboard.PLAYER_ID, 1220, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"playerImage\" class=\"avatar\" height=\"90\" width=\"100\">\r\n");
#nullable restore
#line 38 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a9796dddb60db05bc835ddd26753216138d611319334", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 42 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <b>");
#nullable restore
#line 43 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
          Write(myLeaderboard.Player.PLAYER_USERNAME);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b><br />\r\n        </div>\r\n        <div class=\"col-md-2 text-center\" style=\"border-right: 1px solid black;\">\r\n            <br />\r\n            <b>Level: ");
#nullable restore
#line 47 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
                 Write(myLeaderboard.LEADERBOARD_LEVEL);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b><br />\r\n            <b>Win Rate: ");
#nullable restore
#line 48 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
                    Write(myLeaderboard.LEADERBOARD_WINRATE);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</b>\r\n        </div>\r\n        <div class=\"col-md-2 text-center\">\r\n            <br />\r\n            <b>Wins: ");
#nullable restore
#line 52 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
                Write(myLeaderboard.LEADERBOARD_WINS);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b><br />\r\n            <b>Losses: ");
#nullable restore
#line 53 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
                  Write(myLeaderboard.LEADERBOARD_LOSSES);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</b>
        </div>
    </div>
</div>

<br />

<h1 class=""text-center"" style=""font-family:Game_Time"">All Leaderboard Ranks</h1>

<div class=""container pt-2 pb-2"" style=""background-color:rgba(186, 185, 129, 0.81); border-radius: 5px;"">
    <table id=""leaderboardTable""");
            BeginWriteAttribute("class", " class=\"", 2274, "\"", 2282, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width:100%"">
        <thead style=""background-color:rgba(230, 215, 218, 0.90);"">
            <tr>
                <th class=""text-center"" style=""border-color:black; border-style: solid; border-width:thin; border-radius: 5px;"">Rankings</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 70 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
             for (int cnt = 0; cnt < tmp.Length; cnt++)
            {
                var leaderTemp = tmp[cnt];
                leaderTemp.Player = m.PlayerGetById(tmp[cnt].PLAYER_ID);
                var rank = cnt + 1;


#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <tr>
                    <td>
                        <div class=""row"" style=""background-color:rgba(230, 215, 218, 0.90); font-size:16px; border-color:black; border-style: solid; border-width:thin; border-radius:5px"">
                            <div class=""col-md-2"" style=""border-right: 1px solid black;"">
                                <br />
                                <b>Rank: ");
#nullable restore
#line 81 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
                                    Write(rank);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                            </div>\r\n                            <div class=\"col-md-6\" style=\"border-right: 1px solid black;\">\r\n");
#nullable restore
#line 84 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
                                 if (leaderTemp.Player.PLAYER_AVATAR.Length != 0)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <img");
            BeginWriteAttribute("src", " src=\"", 3523, "\"", 3557, 2);
            WriteAttributeValue("", 3529, "/photo/", 3529, 7, true);
#nullable restore
#line 86 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
WriteAttributeValue("", 3536, leaderTemp.PLAYER_ID, 3536, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"playerImage\" class=\"avatar\" height=\"90\" width=\"100\">\r\n");
#nullable restore
#line 87 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a9796dddb60db05bc835ddd26753216138d6113116169", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 91 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <b>");
#nullable restore
#line 92 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
                              Write(leaderTemp.Player.PLAYER_USERNAME);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b><br />\r\n                            </div>\r\n                            <div class=\"col-md-2 text-center\" style=\"border-right: 1px solid black;\">\r\n                                <br />\r\n                                <b>Level: ");
#nullable restore
#line 96 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
                                     Write(leaderTemp.LEADERBOARD_LEVEL);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b><br />\r\n                                <b>Win Rate: ");
#nullable restore
#line 97 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
                                        Write(leaderTemp.LEADERBOARD_WINRATE);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</b>\r\n                            </div>\r\n                            <div class=\"col-md-2 text-center\">\r\n                                <br />\r\n                                <b>Wins: ");
#nullable restore
#line 101 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
                                    Write(leaderTemp.LEADERBOARD_WINS);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b><br />\r\n                                <b>Losses: ");
#nullable restore
#line 102 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
                                      Write(leaderTemp.LEADERBOARD_LOSSES);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                            </div>\r\n                        </div>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 107 "C:\Users\c0679\Desktop\School\Winter 2020\PRJ566\Imperium Website\ImperiumSite\ImperiumSite\Views\Leaderboard\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n<br/>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ImperiumSite.Models.LeaderboardBaseViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591