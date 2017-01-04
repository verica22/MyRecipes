debugger;
var orderItems = [];
//Add button click function
$('#add').click(function () {
    //Check validation of order item
    debugger;
    var isValidItem = true;
    if ($('#ingredientsName').val().trim() == '') {
        isValidItem = false;
        $('#ingredientsName').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#ingredientsName').siblings('span.error').css('visibility', 'hidden');
    }

    if (!($('#quantity').val().trim() != '' && !isNaN($('#quantity').val().trim()))) {
        isValidItem = false;
        $('#quantity').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#quantity').siblings('span.error').css('visibility', 'hidden');
    }

    //Add item to list if valid
    if (isValidItem) {
        orderItems.push({
            IngredientName: $('#ingredientsName').val().trim(),
            Quantity: parseInt($('#quantity').val().trim()),
            Measurement: $('#measurementId').val().trim(),
        });
        //Clear fields
        $('#ingredientsName').val('').focus();
        $('#quantity').val('');
        $('#measurementId').val('');

    }
    //populate order items
    GeneratedItemsTable();

});
//Save button click function
debugger;
$('#submit').click(function () {
    //validation of order
    debugger;
    var isAllValid = true;
    if (orderItems.length == 0) {
        $('#orderItems').html('<span style="color:red;">Please add ingredients</span>');
        isAllValid = false;
    }

    if ($('#recipeName').val().trim() == '') {
        $('#recipeName').siblings('span.error').css('visibility', 'visible');
        isAllValid = false;
    }
    else {
        $('#recipeName').siblings('span.error').css('visibility', 'hidden');
    }

    //Save if valid
    if (isAllValid) {
        debugger;
        var data = {
            Id: $("#recipeId").val(),
            Name: $('#recipeName').val().trim(),
            Description: $('#description').val().trim(),
            Done: $('#doneRecipe').is(":checked"),
            Favorites: $('#favouriteRecipe').is(":checked"),
            //  Measurements: $('#measurementId').val(),
            RecipeIngredients: orderItems
        }

        $(this).val('Please wait...');
        debugger;
        $.ajax({

            url: '/Recipes/Save',
            type: "POST",
            data: JSON.stringify(data),
            dataType: "JSON",
            contentType: "application/json",

            success: function (d) {
                debugger;
                //check is successfully save to database
                if (d.status == true) {
                    //will send status from server side
                    alert('Successfully done.');
                    windows.location.href = d.Url
                    //clear form
                    //orderItems = [];
                    //$('#recipeName').val('');
                    //$('#description').val('');
                    //$('#orderItems').empty();
                }
                else {
                    alert('Failed');
                }
                $('#submit').val('Save');
            },
            error: function (err) {
                alert('Error. Please try again.');
                $('#submit').val('Save');
            }
        });
    }

});
//function for show added items in table
function GeneratedItemsTable() {
    debugger;
    if (orderItems.length > 0) {
        var $table = $('<table/>');
        $table.append('<thead><tr><th>Name</th><th>Quantity</th><th>Measurement</th><th></th></tr></thead>');
        var $tbody = $('<tbody/>');
        $.each(orderItems, function (i, val) {
            var $row = $('<tr/>');
            $row.append($('<td/>').html(val.IngredientName));
            $row.append($('<td/>').html(val.Quantity));
            $row.append($('<td/>').html(val.Measurement));
            var $remove = $('<a href="#">Remove</a>');
            $remove.click(function (e) {
                e.preventDefault();
                orderItems.splice(i, 1);
                GeneratedItemsTable();
            });
            $row.append($('<td/>').html($remove));
            $tbody.append($row);
        });
        console.log("current", orderItems);
        $table.append($tbody);
        $('#orderItems').html($table);
    }
    else {
        $('#orderItems').html('');
    }
}
