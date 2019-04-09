ComboBox = function (object_name) {
    // Edit element cache
    this.edit = document.getElementById(object_name);
    // Items Container
    var ddl = document.getElementById(object_name).parentNode.getElementsByTagName('DIV');
    this.dropdownlist = ddl[0];
    // Current Item
    this.currentitem = null;

    var theObject = this;
    // Picker
    var pick = document.getElementById(object_name).parentNode.getElementsByTagName('SPAN');
    pick[0].onclick = function () {
        console.log("picked");
        theObject.edit.focus();
    };
    // Show Items when edit get focus
    this.edit.onfocus = function () {
        theObject.dropdownlist.style.display = 'block';
    };
    // Hide Items when edit lost focus
    this.edit.onblur = function () {
        if (allowLoose) {
            setTimeout(function () {
                    theObject.dropdownlist.style.display = 'none';}, 10);
        }
    };
    var allowLoose = true;
    theObject.dropdownlist.onmousedown = function (event) {
        allowLoose = false;
        return false;
    };
    theObject.dropdownlist.onmouseup = function (event) {
        setTimeout(function () {
            allowLoose = true;
        }, 10);
        return false;
    };
    // Get Items
    this.listitems = this.dropdownlist.getElementsByTagName('A');
    for (var i = 0; i < this.listitems.length; i++) {
        var t = i;
        this.listitems[i].onclick = function () {
            var theValue = this.innerHTML;
            theObject.edit.value = theValue;
            theObject.dropdownlist.style.display = 'none';
            return false;
        };
       this.listitems[i].onmouseover = function () {
            for (var i = 0; i < theObject.listitems.length; i++) {
                if (this === theObject.listitems[i]) {
                    if (theObject.currentitem) {
                        theObject.currentitem.className = theObject.currentitem.className.replace(/light/g, '');
                    }
                    theObject.currentitem = theObject.listitems[i];
                    theObject.currentitemindex = i;
                    theObject.currentitem.className += ' light';
                }
            }
        }
    }
};
