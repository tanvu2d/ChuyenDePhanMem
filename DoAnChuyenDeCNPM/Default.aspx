<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Default.aspx.cs" Inherits="DoAnChuyenDeCNPM._Default" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v20.2, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    
    
         <div id="header">
               <asp:Label ID="LabelTitle" runat="server" Text="Nhập tiêu đề báo cáo: "></asp:Label>
                <asp:TextBox ID="TextBoxNhapTieuDe" runat="server"></asp:TextBox>       
        </div>
        <div id="main">
            <div id="table-content">
                
                
                    <br />
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Chon table">
                    </dx:ASPxLabel>
                    <br />
                    <br />
                    <asp:CheckBoxList ID="CheckBoxListTable" runat="server" Width="348px" OnSelectedIndexChanged="CheckBoxListTable_SelectedIndexChanged1" AutoPostBack="True">
                    </asp:CheckBoxList>
                    


               
                
            </div>
        
            <div id="column-content">
                
                <br />
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" Height="58px" style="margin-top: 0px" Width="307px">
                    <PanelCollection>
<dx:PanelContent runat="server">
    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="ASPxLabel">
    </dx:ASPxLabel>
    <asp:CheckBoxList ID="CheckBoxListColumn" runat="server" Height="20px" OnSelectedIndexChanged="CheckBoxListColumn_SelectedIndexChanged" Width="500px">              
                    </asp:CheckBoxList>
                        </dx:PanelContent>
</PanelCollection>
                </dx:ASPxPanel>
                <br />
                
            </div>

            <div id="query-content">
                
                       
                
                <br />
                <dx:ASPxPanel ID="ASPxPanel3" runat="server" Height="209px" Width="888px">
                                        <PanelCollection>
                    <dx:PanelContent runat="server">
                        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                            <Columns>
                                 <asp:TemplateField>
                               <HeaderTemplate>
                                   <asp:CheckBox ID="checkHeader" runat="server" AutoPostBack="true" Text="Chọn tất cả" OnCheckedChanged ="checkHeader_CheckedChanged"/>
                               </HeaderTemplate>
                                   <ItemTemplate>
                                      <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged ="CheckBox1_CheckedChanged"/>
                                   </ItemTemplate>
                           </asp:TemplateField>

                            
                            <asp:TemplateField HeaderText="State" >
                               <ItemTemplate>
                                   <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="Non_Selected" Value=""></asp:ListItem>
                                        <asp:ListItem Text="SORT ASC" Value="ASC"></asp:ListItem>
                                        <asp:ListItem Text="SORT DESC" Value="DESC"></asp:ListItem>
                                        <asp:ListItem Text="COUNT" Value="COUNT"></asp:ListItem>
                                        <asp:ListItem Text="MIN" Value="MIN"></asp:ListItem>                                     
                                        <asp:ListItem Text="MAX" Value="MAX"></asp:ListItem>
                                   </asp:DropDownList>
                                </ItemTemplate>
                           </asp:TemplateField>           
              
                   
                           <asp:TemplateField HeaderText="Điều Kiện">
                               <ItemTemplate>
                                   <asp:TextBox ID="TextBoxDieuKien" runat="server"></asp:TextBox>
                               </ItemTemplate>
                           </asp:TemplateField>

                            </Columns>


                            <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left"/>
                       <HeaderStyle BackColor="#006699" Font-Bold="true" ForeColor="White"/>
                       <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left"/>
                       <RowStyle ForeColor="#000066"/>
                       <SelectedRowStyle BackColor="#006699" ForeColor="White" Font-Bold="true"/>
                       <SortedAscendingCellStyle BackColor="#000066"/>
                       <SortedAscendingHeaderStyle BackColor="#000066"/>
                       <SortedAscendingCellStyle BackColor="#007DBB"/>
                       <SortedDescendingCellStyle BackColor="#CAC9C9"/>
                       <SortedDescendingHeaderStyle BackColor="#00547E"/>


                        </asp:GridView>

                        
                    <br />
                    <asp:Label ID="lbltxt" runat="server"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="ButtonQuery" runat="server" OnClick="ButtonQuery_Click" Text="Tạo QUERY" />
                    <br />
                    <br />
                          
                    <asp:Label ID="LabelMess" runat="server"></asp:Label>
                    <br />
                    <br />


                      </dx:PanelContent>
                    </PanelCollection>

                </dx:ASPxPanel>
                <br />
                <br />
                <br />
                
                       
                
                <br />
                <br />
                
                       
                
            </div>

            <div id="report-content" style="height: 143px">        
               
              <br />   
                
                <br />
                <br />
               
                <dx:ASPxButton ID="ASPxButton1" runat="server" OnClick="ASPxButton1_Click1" Text="ASPxButton">
                </dx:ASPxButton>
               
            </div>
        </div>
        </asp:Content>