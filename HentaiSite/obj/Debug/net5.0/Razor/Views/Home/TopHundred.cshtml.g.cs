#pragma checksum "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f94357df19808f6b24b9502cb26de352335054a4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_TopHundred), @"mvc.1.0.view", @"/Views/Home/TopHundred.cshtml")]
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
#line 1 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\_ViewImports.cshtml"
using HentaiSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\_ViewImports.cshtml"
using HentaiSite.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f94357df19808f6b24b9502cb26de352335054a4", @"/Views/Home/TopHundred.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43bf5461a9bdafb27daa4113189ead8e01861418", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_TopHundred : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<HentaiSite.Models.Post>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/search.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/search.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("clickable-yellow"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
  
    ViewData["Title"] = "Home Page";
    string imgName;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f94357df19808f6b24b9502cb26de352335054a45302", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f94357df19808f6b24b9502cb26de352335054a46637", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 15 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral(@"
<div class=""main-title"">

    <div class=""tag-cloud-search"">
        <ul>

            <li>Юри</li>
            <li>Анал</li>
            <li>Большие сиськи</li>
            <li>Минет</li>
            <li>Инцест</li>
            <li>Групповой</li>
            <li>Студентки</li>
            <li>Мастурбация</li>
            <li>Девственницы</li>
            <li>Футунари</li>
            <li>Кошкодевочки</li>

        </ul>
    </div>

</div>

<div class=""content-sort-wrap"">
    <div>
        <span>Сортировать по:</span>
    </div>

    <div class=""content-sort"">
        <span>По имени</span>
        <span class=""sort-active"">По рейтингу</span>
        <span>По дате</span>
        <span>По просомтрам</span>
    </div>

</div>

<div class=""content-list"">


");
#nullable restore
#line 57 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
     foreach (Post post in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"content-block\">\r\n\r\n            <div class=\"content-block-overlay\">\r\n");
#nullable restore
#line 62 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
                 if (post.Censured)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span>Censure</span>\r\n");
#nullable restore
#line 65 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span>No censure</span>\r\n");
#nullable restore
#line 69 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 1471, "\"", 1495, 2);
            WriteAttributeValue("", 1478, "/post?id=", 1478, 9, true);
#nullable restore
#line 72 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
WriteAttributeValue("", 1487, post.ID, 1487, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f94357df19808f6b24b9502cb26de352335054a411079", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1525, "~/img/3-2-", 1525, 10, true);
#nullable restore
#line 73 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
AddHtmlAttributeValue("", 1535, post.ImgName, 1535, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </a>\r\n\r\n            <div class=\"post-info-search\">\r\n                <span class=\"post-title-search\">");
#nullable restore
#line 77 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
                                           Write(post.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                <span class=\"post-year-search\">");
#nullable restore
#line 78 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
                                          Write(post.ReleaseYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n");
#nullable restore
#line 80 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
                 if (post.EndingYear != 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span> - </span>\r\n                    <span>");
#nullable restore
#line 83 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
                     Write(post.EndingYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 84 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"post-tags-search\">\r\n");
#nullable restore
#line 87 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
                     if (post.Tags != null)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 89 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
                         foreach (Tag tag in post.Tags)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f94357df19808f6b24b9502cb26de352335054a414738", async() => {
#nullable restore
#line 91 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
                                                                        Write(tag.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2177, "~/tag/", 2177, 6, true);
#nullable restore
#line 91 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
AddHtmlAttributeValue("", 2183, tag.ID, 2183, 7, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 92 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 97 "C:\Users\Aleksandr\Desktop\HentaiSite\HentaiSite\Views\Home\TopHundred.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


</div>

<ul class=""pagination"">
    <li class=""disabled""><a href=""#""><</a></li>
    <li class=""disabled""><a href=""#"">1</a></li>
    <li><a href=""#"">2</a></li>
    <li><a href=""#"">3</a></li>
    <li><a href=""#"">4</a></li>
    <li><a href=""#"">5</a></li>
    <li><a href=""#"">6</a></li>
    <li><a href=""#"">...</a></li>
    <li><a href=""#"">23</a></li>
    <li><a href=""#"">24</a></li>
    <li><a href=""#"">></a></li>
</ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<HentaiSite.Models.Post>> Html { get; private set; }
    }
}
#pragma warning restore 1591
