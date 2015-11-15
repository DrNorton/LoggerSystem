$( document ).ready( function () {

	var socket;
    var logEl = $("#log");
    var popup = $('#popup1');
    var popup2 = $('#popup2');
	var connectBtn = $( '#connectButton' );
	var disconnectBtn = $( '#disconnectButton' );

	function connect() {
	      $.ajax({
	        url: 'http://localhost:64711/api/Data/GetPlatforms',
	        type: 'POST',
	        dataType: 'json',
	        
	        success: function (data, textStatus, xhr) {
	            var platforms = data.Result;
	            createPlatformsTable(platforms);
	            popup2.modal('show');
	        },
	        error: function (xhr, textStatus, errorThrown) {
	            console.log('Error in Operation');
	        }
	    });
	}

	function disconnect() {
	
	}
	function clear() {
		$( '#log' ).html( '' );
	}

	function attach( guid ) {
		socket.send( "attach:" + guid );

	}

    function createPlatformsTable(platforms) {
        var table = $("#platformsTable tr").remove();
   
        for (index = 0; index < platforms.length; ++index) {
            $("#platformsTable tbody").append(
					"<tr>" +
					"<td class='guid'>" + platforms[index].Id + "</td>" +
					"<td class='model'>" + platforms[index].PlatformName + "</td>" +
					
					'<td class="image"><img data-src="holder.js/200x200" class="img-thumbnail" alt="200x200" src="'+platforms[index].Icon+ '"data-holder-rendered="true" style="width: 200px; height: 200px;"></td>'
					+ "</tr>");
        }
    }

	function createPhoneTable( telephones ) {
		var table = $( "#phoneTable" );
		for ( index = 0; index < telephones.length; ++index ) {
			$( "#phoneTable tbody" ).html('').append(
					"<tr>" +
					"<td>" + telephones[index].Id + "</td>" +
					"<td class='model'>" + telephones[index].Name + "</td>" +
					"<td class='time'>" + telephones[index].Time + "</td>" +
					"<td class='guid'>" + telephones[index].Guid + "</td>" +
					'<td class="image"><img data-src="holder.js/200x200" class="img-thumbnail" alt="200x200" src="./Content/images/' + telephones[index].Name + '.png "data-holder-rendered="true" style="width: 200px; height: 200px;"></td>'
					+ "</tr>" );
		}
	}

	connectBtn.on( 'click', connect );
	disconnectBtn.on( 'click', disconnect );
	$('#clearButton').on( 'click', clear );

	$( '#phoneTable' ).on( 'click', 'tr', function () {
		var cell = $( this );
		var guid = cell.find( ".guid" ).html();
	
		popup2.modal('hide');
	    popup.modal('show');
	});

	$('#platformsTable').on('click', 'tr', function () {
	    var cell = $(this);
	    var guid = cell.find(".guid").html();
	    $('.phone-name').html(cell.find(".model").html());
	    $('.phone-time').html(cell.find(".time").html());
	    $('.phone-guid').html(guid);
	    $('.phone-image').html(cell.find(".image").html());
	    $.ajax({
	        url: 'http://localhost:64711/api/Data/GetDevicesByPlatform',
	        type: 'POST',
	        data: { "Id": guid },
	        dataType: 'json',

	        success: function (data, textStatus, xhr) {
	            var devices = data.Result;
	            createPhoneTable(devices);
	            popup.modal('show');
	        },
	        error: function (xhr, textStatus, errorThrown) {
	            console.log('Error in Operation');
	        }
	    });
	    popup2.modal('hide');
	
	});

	function scroll() {
	    var scrollHeight = logEl[0].scrollHeight;
		var scrollTop = logEl.scrollTop();
		var innerHeight = logEl.innerHeight();
		var lastItem = logEl.find( '.item' ).last().outerHeight() + 20;
		var diff = scrollHeight - scrollTop - lastItem;
		if ( diff - innerHeight < 5 ) {
			logEl.animate( {
				scrollTop: scrollHeight
			}, 500 );
		}

	};
});

       

        
