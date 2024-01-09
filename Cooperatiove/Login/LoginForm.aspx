<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="Cooperatiove.Login.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
            <meta charset="UTF-8" />
        <!-- <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">  -->
        <title>Login and Registration Form with HTML5 and CSS3</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0"> 
        <meta name="description" content="Login and Registration Form with HTML5 and CSS3" />
        <meta name="keywords" content="html5, css3, form, switch, animation, :target, pseudo-class" />
        <meta name="author" content="Codrops" />
        <link rel="shortcut icon" href="../favicon.ico"> 
        <link rel="stylesheet" type="text/css" href="css/demo.css" />
        <link rel="stylesheet" type="text/css" href="css/style.css" />
		<link rel="stylesheet" type="text/css" href="css/animate-custom.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="container">
            <!-- Codrops top bar -->
           <%-- <div class="codrops-top">
                <a href="">
                    <strong>&laquo; Previous Demo: </strong>Responsive Content Navigator
                </a>
                <span class="right">
                    <a href=" http://tympanus.net/codrops/2012/03/27/login-and-registration-form-with-html5-and-css3/">
                        <strong>Back to the Codrops Article</strong>
                    </a>
                </span>
                <div class="clr"></div>
            </div><!--/ Codrops top bar -->
            <header>
                <h1>Login and Registration Form <span>with HTML5 and CSS3</span></h1>
				<nav class="codrops-demos">
					<span>Click <strong>"Join us"</strong> to see the form switch</span>
					<a href="index.html" class="current-demo">Demo 1</a>
					<a href="index2.html">Demo 2</a>
					<a href="index3.html">Demo 3</a>
				</nav>
            </header>--%>
            <section>				
                <div id="container_demo" style="margin-top: 8%;" >
                    <!-- hidden anchor to stop jump http://www.css3create.com/Astuce-Empecher-le-scroll-avec-l-utilisation-de-target#wrap4  -->
                    <a class="hiddenanchor" id="toregister"></a>
                    <a class="hiddenanchor" id="tologin"></a>
                    <div id="wrapper">
                        <div id="login" class="animate form">
                            <form  action="mysuperscript.php" autocomplete="on"> 
                                <h1>Log in</h1> 
                                <p> 
                                    <label for="username" class="uname" data-icon="u" > Your email or username </label>
                                    <asp:TextBox ID="txtusername" runat="server" placeholder="myusername or mymail@mail.com"></asp:TextBox>
                                </p>
                                <p> 
                                    <label for="password" class="youpasswd" data-icon="p"> Your password</label>
                                   <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" placeholder="eg. X8df!90EO"></asp:TextBox>
                                     </p>
                                <p class="keeplogin"> 
                                    <asp:CheckBox ID="cbtxtloginkeeping" runat="server" />
                                    <label for="loginkeeping">Keep Me Logged In</label>
								</p>
                                <p class="login button"> 
                                    <asp:Button ID="submit" runat="server" Text="LOGIN" />
                                    </p>
                                <p class="change_link">
									Not a Member yet?
									<a href="#toregister" class="to_register">Join us</a>
								</p>
                            </form>
                        </div>

                        <div id="register" class="animate form">
                            <form  action="mysuperscript.php" autocomplete="on"> 
                                <h1> Sign up </h1> 
                                <p> 
                                    <label for="usernamesignup" class="uname" data-icon="u">Your username</label>
                                    <asp:TextBox ID="txtusernamesignup" runat="server" placeholder="mysuperusername690"></asp:TextBox>
                                     </p>
                                <p> 
                                    <label for="emailsignup" class="youmail" data-icon="e" > Your email</label>
                                    <asp:TextBox ID="txtemailsignup" runat="server" placeholder="mysupermail@mail.com"></asp:TextBox>
                                    </p>
                                <p> 
                                    <label for="passwordsignup" class="youpasswd" data-icon="p">Your password </label>
                                    <asp:TextBox ID="txtpasswordsignup" runat="server" placeholder="eg. X8df!90EO" TextMode="Password" ></asp:TextBox>
                                   </p>
                                <p> 
                                    <label for="passwordsignup_confirm" class="youpasswd" data-icon="p">Please confirm your password </label>
                                    <asp:TextBox ID="txtpasswordsignup_confirm" runat="server" TextMode="Password" placeholder="eg. X8df!90EO"></asp:TextBox>
                                    </p>
                                <p class="signin button"> 
                                    <asp:Button ID="btnsubmitt" runat="server" Text="Submit" ></asp:Button>
                                    	    </p>
                                <p class="change_link">  
									Already a member ?
									<a href="#tologin" class="to_register"> Go and log in </a>
								</p>
                            </form>
                        </div>
						
                    </div>
                </div>  
            </section>
        </div>
    </div>
    </form>
</body>
</html>
