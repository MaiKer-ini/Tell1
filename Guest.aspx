<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Guest.aspx.cs" Inherits="liuyanban.Guest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>留言板</title>
    <style type="text/css">
        body
        {
            background-image: url(Images/01.jpg);
        }
        .style1
        {
            font-size: large;
            color: #3333CC;
        }
        .style5
        {
            width: 338px;
        }
    </style>
</head>
<body>
    <h2 align="center">
        留言板
    </h2>
    <div align="center">
        <center>
            <table border="0" height="115" cellpadding="0" style="width: 80%">
                <tr>
                    <td width="100%" align="center" height="166">
                        <h3>
                            欢迎对本站内容提出您宝贵的意见与建议，请遵守如下规则：</h3>
                        <p align="left">
                            1. 您的留言应遵守国家的法律法规；
                        </p>
                        <p align="left">
                            2. 您的留言应尊重他人，不得对他人构成任何形式的侵害；</p>
                        <p align="left">
                            3. 本站保留修改和删除留言的权利。</p>
                        <p align="left">
                        </p>
                    </td>
                </tr>
                <tr>
                    <td height="208" align="center">
                        <form id="form1" runat="server">
                        <table border="0" cellspacing="0" cellpadding="3" style="width: 372px; height: 222px">
                            <tr>
                                <td height="18" valign="top" bgcolor="#CCFFFF" class="style5">
                                </td>
                            </tr>
                            <tr>
                                <td height="31" valign="top" bgcolor="#CCFFFF" class="style5">
                                    <div>
                                        <asp:Label ID="Label1" runat="server" Text="请输入留言内容！" Style="font-size: x-large"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td height="160" valign="top" bgcolor="#CCFFFF" class="style5">
                                    <div>
                                        <asp:TextBox ID="Contents" runat="server" Columns="50" TextMode="MultiLine" Style="word-wrap: break-word;
                                            margin-top: 10px;" Height="142px" Width="520px"></asp:TextBox>
                                    </div>
                                    <div align="right" style="width: 365px">
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <p align="center">
                            <asp:Button ID="Button1" runat="server" Text="提交留言" Height="30px" OnClick="Button1_Click" />
                            <asp:Button ID="Button2" runat="server" Text="浏览留言" Height="30px" OnClick="Button2_Click" />
                        </p>
                        <p class="style1">
                            &nbsp;</p>
                        </form>
                    </td>
                </tr>
            </table>
        </center>
    </div>
</body>
</html>
