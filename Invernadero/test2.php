<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
    <head>
        <title>Ajax</title>
        <link rel="stylesheet" type="text/css" href="index_styling.css" />
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

        <script type="text/javascript">

            function Ajax() {
                var $http, $self = arguments.callee;

                if (window.XMLHttpRequest) {
                    $http = new XMLHttpRequest();
                } else if (window.ActiveXObject) {
                    try {
                        $http = new ActiveXObject('Msxml2.XMLHTTP');
                    } catch (e) {
                        $http = new ActiveXObject('Microsoft.XMLHTTP');
                    }
                }

                if ($http) {
                    $http.onreadystatechange = function () {
                        if (/4|^complete$/.test($http.readyState)) {

                            var JSONObject = JSON.parse($http.responseText);

                            document.getElementById('T1').innerHTML = "T1: " + JSONObject.T1;
                            document.getElementById('T2').innerHTML = "T2: " + JSONObject.T2;
                            document.getElementById('T3').innerHTML = "T3: " + JSONObject.T3;
                            document.getElementById('T4').innerHTML = "T4: " + JSONObject.T4;
                            document.getElementById('T5').innerHTML = "T5: " + JSONObject.T5;
                            document.getElementById('T6').innerHTML = "T6: " + JSONObject.T6;
                            document.getElementById('T7').innerHTML = "T7: " + JSONObject.T7;
                            document.getElementById('T8').innerHTML = "T8: " + JSONObject.T8;
                            document.getElementById('T9').innerHTML = "T9: " + JSONObject.T9;
                            document.getElementById('T10').innerHTML = "T10: " + JSONObject.T10;
                            document.getElementById('T11').innerHTML = "T11: " + JSONObject.T11;
                            document.getElementById('T12').innerHTML = "T12: " + JSONObject.T12;
                            document.getElementById('T13').innerHTML = "T13: " + JSONObject.T13;
                            document.getElementById('T14').innerHTML = "T14: " + JSONObject.T14;
                            document.getElementById('T15').innerHTML = "T15: " + JSONObject.T15;
                            document.getElementById('T16').innerHTML = "T16: " + JSONObject.T16;

                            setTimeout(function () { $self(); }, 5000);
                        }
                    };
                    $http.open('GET', 'hola' + '?' + new Date().getTime(), true);
                    $http.send(null);
                }

            }

        </script>

    </head>
    <body>

        <script type="text/javascript">
            setTimeout(function () { Ajax(); }, 5000);
        </script>
<div style="background:url(TYP400101_PNG.dat) no-repeat;width:1512px;height:794px">
        <div id="T1"></div>
        <div id="T2"></div>
        <div id="T3"></div>
        <div id="T4"></div>
        <div id="T5"></div>
        <div id="T6"></div>
        <div id="T7"></div>
        <div id="T8"></div>
        <div id="T9"></div>
        <div id="T10"></div>
        <div id="T11"></div>
        <div id="T12"></div>
        <div id="T13"></div>
        <div id="T14"></div>
        <div id="T15"></div>
        <div id="T16"></div>
</div>
    </body>
</html>