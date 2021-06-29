#pragma checksum "D:\C# Formation\Solution\FilRouge\ProjetFilRouge AspNET\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb4092be78b17332f79b42019219a74c8f0d28d0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\C# Formation\Solution\FilRouge\ProjetFilRouge AspNET\Views\_ViewImports.cshtml"
using ProjetFilRouge_AspNET;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C# Formation\Solution\FilRouge\ProjetFilRouge AspNET\Views\_ViewImports.cshtml"
using ProjetFilRouge_AspNET.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\C# Formation\Solution\FilRouge\ProjetFilRouge AspNET\Views\_ViewImports.cshtml"
using ProjetFilRouge_AspNET.Classes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\C# Formation\Solution\FilRouge\ProjetFilRouge AspNET\Views\_ViewImports.cshtml"
using ProjetFilRouge_AspNET.DAO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\C# Formation\Solution\FilRouge\ProjetFilRouge AspNET\Views\_ViewImports.cshtml"
using ProjetFilRouge_AspNET.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb4092be78b17332f79b42019219a74c8f0d28d0", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b79dcc842977866091c478217a7586b6e9d358f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\C# Formation\Solution\FilRouge\ProjetFilRouge AspNET\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Accueil";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\C# Formation\Solution\FilRouge\ProjetFilRouge AspNET\Views\Home\Index.cshtml"
 if (ViewBag.connection == true)
{
    Layout = "_LayoutConnecter";
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 10 "D:\C# Formation\Solution\FilRouge\ProjetFilRouge AspNET\Views\Home\Index.cshtml"
 if (ViewBag.message != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row m-1 justify-content-center align-items-center\">\r\n        <div class=\"col alert alert-success p-1\">\r\n            ");
#nullable restore
#line 14 "D:\C# Formation\Solution\FilRouge\ProjetFilRouge AspNET\Views\Home\Index.cshtml"
       Write(ViewBag.message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 17 "D:\C# Formation\Solution\FilRouge\ProjetFilRouge AspNET\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 19 "D:\C# Formation\Solution\FilRouge\ProjetFilRouge AspNET\Views\Home\Index.cshtml"
 if (ViewBag.messageError != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row m-1 justify-content-center align-items-center\">\r\n        <div class=\"col alert alert-danger p-1\">\r\n            ");
#nullable restore
#line 23 "D:\C# Formation\Solution\FilRouge\ProjetFilRouge AspNET\Views\Home\Index.cshtml"
       Write(ViewBag.messageError);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 26 "D:\C# Formation\Solution\FilRouge\ProjetFilRouge AspNET\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Bienvenue dans l'entraide entre développeurs</h1>


<p>CommonWeb, qu’est-ce que c’est ?</p>
<p>
    Le groupe CommonWeb, regroupe des développeurs & intégrateurs web en freelance qui souhaitent rejoindre un groupe de discussion autour de leur domaine d’expertise, à savoir : le Web
</p>

<p>
    Il est destiné uniquement aux développeurs & intégrateurs en freelance afin de garder une cohérence dans les échanges. Les différents canaux te permettront d’obtenir des réponses à tes questions et interrogations grâce à l’expérience des autres membres du groupe, que ta question aborde la technique ou les spécificité du statut de freelancer.
</p>

<p>
    Il s’adresse donc principalement aux freelances du domaine du web et te permettra d’obtenir et de fournir de l’aide grâce à un groupe de compères passionnés et rencontrant les mêmes problématiques que toi.
</p>

<p>
    Le groupe a également vocation de fournir un espace de convivialité entre pairs comme tu pourrais en bénéficier dans un espace ");
            WriteLiteral("de co-working physique. Nous sommes là pour discuter sérieusement mais également rire et échanger !\r\n</p>\r\n\r\n<p><img src=\"https://substance.etsmtl.ca/wp-content/uploads/2018/12/Ali-ouni-0.jpg\" />\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
