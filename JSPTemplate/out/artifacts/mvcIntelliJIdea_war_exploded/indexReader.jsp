<%--
  Created by IntelliJ IDEA.
  User: diago
  Date: 6/14/2019
  Time: 11:18 AM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Title</title>
    <script src="jquery.js"></script>
</head>
<body>
<% String username = (String) session.getAttribute("username"); %>
<%if (username==null)response.sendRedirect("/Login.jsp");%>
<h2>You are logged in  reader, <%= username%>
</h2>
<h2>Last 4 contents</h2><br>
<div id='lastContent'></div>



<script>
    var crt=0;
    var newsList=[];
    var prevList=[];
    setInterval(slideShow,2000);

    function getLastNews(){
        console.log("getLast4");
        $.post("LastContent",{},
            function (data) {
                console.log(data);
                prevList=newsList;

                newsList=data.split(';');
                console.log("ADDDDD"+data);
                if (hasChanged()){
                    alert('Content arrived');
                    console.log('ALEEEEEERRTTTTTT');
                }
            });
    }
    function slideShow(){
        getLastNews();
        console.log("slideShow");
        if(newsList.length>0){
            console.log('asd'+crt);
            let crtNews=newsList[crt].split(',');
            console.log(newsList.length+' '+crt);
            $('#lastContent').html('<h3>title: '+crtNews[1]+'</h3>'+'<h3>description: '+crtNews[2]+'</h3>'+
                '<h3>url: '+crtNews[3]+'</h3>');
            crt=(crt + 1) % Math.min(5,newsList.length-1);

        }
    }
    function hasChanged(){
        $.post("hasChanged",{"current":"crt"}, function(data){
            if (data=="yes"){
                alert("CONTENT HAS ARRIVED");
            }
        } );
        let maxCrt=0, maxPrev=0;
        for(var i=0;i<newsList.length;i++){
            let crtId=newsList[i].split(',')[0];
            if (crtId>maxCrt){
                maxCrt=crtId;
            }
        }

        for(var i=0;i<prevList.length;i++){
            let crtId=prevList[i].split(',')[0];
            if (crtId>maxPrev){
                console.log('DDDDDDDDDAAAAANNNNNAA', crtId);
                maxPrev=crtId;
            }
        }
        if (maxCrt>maxPrev){
            alert('Content arrived');
            console.log("ALEEEEEEEEEEEERT");
        }
        console.log("MAXPREV",maxPrev,"MAXCRT", maxCrt);
        return maxCrt>maxPrev;

    }


</script>";

</body>
</html>
