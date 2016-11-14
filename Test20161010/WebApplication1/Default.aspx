<%@ Page Title="李双全的个人网站" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <p>
                权哥
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>:<asp:Image ID="Image1" runat="server" Height="279px" ImageUrl="~/QQ截图20160802133503.png" Width="324px" />
        <asp:Image ID="Image2" runat="server" ImageUrl="~/1.png" Width="448px" />
        <asp:Image ID="Image3" runat="server" ImageUrl="~/33333.jpg" Width="460px" />
    </h3>
    <script>
        alert("我是权哥！！！！")
    </script>
    </asp:Content>
