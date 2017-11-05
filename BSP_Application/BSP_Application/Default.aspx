<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BSP_Application._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <!-- Page Content -->
    <div class="container">
        <div class="row">
            <div class="col-lg-3">
                <br /><br /><br />


            </div>
            <!-- /.col-lg-3 -->

            <div class="col-lg-9">
                <br /><br /><br />

                <!-- /.card -->
                <div class="card card-outline-secondary my-4">

                    <div class="card-body">
                        <h4>Iniciar Sessão</h4>
                        <br /><br />
                        <div class="box-body">
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-2 control-label">Username</label>

                                <div class="col-sm-8">
                                    <input type="email" class="form-control" id="inputEmail3" placeholder="Username">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputPassword3" class="col-sm-2 control-label">Password</label>

                                <div class="col-sm-8">
                                    <input type="password" class="form-control" id="inputPassword3" placeholder="Password">
                                </div>
                            </div>

                            <div class="form-group">

                                <div class="col-sm-offset-2 col-sm-10">
                                    <button type="button" class="btn btn-block btn-success" style="width:20%">Iniciar Sessão</button>
                                    <br />
                                    <div class="checkbox">
                                        <a href="">Esqueci-me do username/password</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.card -->
            </div>
            <!-- /.col-lg-9 -->
        </div>
    </div>
    <!-- /.container -->
    <!-- Footer -->
    <footer style="position:fixed;left:0px; bottom:0px; height:30px; width:100%;"class="py-3 bg-dark">
        <div class="container">
           
        </div>
        <!-- /.container -->
    </footer>
</asp:Content>
