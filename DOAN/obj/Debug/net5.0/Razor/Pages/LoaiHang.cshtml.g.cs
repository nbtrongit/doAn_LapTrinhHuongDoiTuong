#pragma checksum "C:\Users\TRONG\Desktop\DoAn_LTHDT\DOAN\Pages\LoaiHang.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58191d23ac462ca042a2714544ea2ef96e33e5d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(DOAN.Pages.Pages_LoaiHang), @"mvc.1.0.razor-page", @"/Pages/LoaiHang.cshtml")]
namespace DOAN.Pages
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
#line 1 "C:\Users\TRONG\Desktop\DoAn_LTHDT\DOAN\Pages\_ViewImports.cshtml"
using DOAN;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58191d23ac462ca042a2714544ea2ef96e33e5d1", @"/Pages/LoaiHang.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"316d1e352639401dff0594474ca7adbf6cb396e5", @"/Pages/_ViewImports.cshtml")]
    public class Pages_LoaiHang : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58191d23ac462ca042a2714544ea2ef96e33e5d13271", async() => {
                WriteLiteral(@"
    <label>Nhập từ khóa</label><br>
    <input type=""text"" name=""tuKhoa"" pattern=""^[^\s]+(\s+[^\s]+)*$""><br>
    <!--Regex không ký tự whitespace ở đầu và cuối-->
    <button type=""submit"" name=""suKien"" value=""Tìm Kiếm"">Tìm Kiếm</button>
    <button type=""submit"" name=""suKien"" value=""Thêm"">Thêm</button>
    <button type=""submit"" name=""suKien"" value=""Sửa"">Sửa</button>
    <button type=""submit"" name=""suKien"" value=""Xóa"">Xóa</button>
    <a href=""index""><button type=""button"">Index</button></a>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\TRONG\Desktop\DoAn_LTHDT\DOAN\Pages\LoaiHang.cshtml"
Write(Model.ketQua);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 15 "C:\Users\TRONG\Desktop\DoAn_LTHDT\DOAN\Pages\LoaiHang.cshtml"
 if (Model.suKien == "True")
{

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58191d23ac462ca042a2714544ea2ef96e33e5d15613", async() => {
                WriteLiteral("\r\n    <br>\r\n    <label>Sửa loại hàng</label><br>\r\n    <label>Tên loại hàng cũ</label>\r\n    <input type=\"text\" name=\"tuKhoa\"");
                BeginWriteAttribute("value", " value=\"", 768, "\"", 789, 1);
#nullable restore
#line 21 "C:\Users\TRONG\Desktop\DoAn_LTHDT\DOAN\Pages\LoaiHang.cshtml"
WriteAttributeValue("", 776, Model.tuKhoa, 776, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" readonly><br>\r\n    <label>Tên loại mới</label>\r\n    <input type=\"text\" name=\"tuKhoaMoi\" pattern=\"^[^\\s]+(\\s+[^\\s]+)*$\" required><br>\r\n    <button type=\"submit\" name=\"suKien\" value=\"Thay Đổi\">Sửa</button>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 26 "C:\Users\TRONG\Desktop\DoAn_LTHDT\DOAN\Pages\LoaiHang.cshtml"
           Write(Model.ketQua);

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\TRONG\Desktop\DoAn_LTHDT\DOAN\Pages\LoaiHang.cshtml"
                             }

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n<table>\r\n    <tr>\r\n        <td>Loại Hàng</td>\r\n    </tr>\r\n");
#nullable restore
#line 32 "C:\Users\TRONG\Desktop\DoAn_LTHDT\DOAN\Pages\LoaiHang.cshtml"
     foreach (string lh in Model.dsLoaiHang)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\r\n    <td>");
#nullable restore
#line 35 "C:\Users\TRONG\Desktop\DoAn_LTHDT\DOAN\Pages\LoaiHang.cshtml"
   Write(lh);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n</tr>");
#nullable restore
#line 36 "C:\Users\TRONG\Desktop\DoAn_LTHDT\DOAN\Pages\LoaiHang.cshtml"
     }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DOAN.Pages.LoaiHangModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DOAN.Pages.LoaiHangModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DOAN.Pages.LoaiHangModel>)PageContext?.ViewData;
        public DOAN.Pages.LoaiHangModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
