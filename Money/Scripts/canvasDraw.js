function pieChart(dataValue, fillColor, can, numSamples) {
    var ctx, radius;
    
    ctx = can.getContext("2d");
    
    radius = can.height / 3;
    var midX = can.width / 2;
    var midY = can.height / 2;

    var total = 0;
    for (var i = 0; i < numSamples; i++) {
	total += dataValue[i];
    }
    ctx.clearRect(0, 0, can.width, can.height);
    var oldAngle = 0;
 
    for (var i = 0; i < numSamples; i++) {
	var portion = dataValue[i] / total;
	var wedge = 2 * Math.PI * portion;
	ctx.beginPath();
	var angle = oldAngle + wedge;
	ctx.arc(midX, midY, radius, oldAngle, angle);
	ctx.lineTo(midX, midY);
	ctx.closePath();
	ctx.fillStyle = fillColor[i];
	ctx.fill();    // fill with wedge color
	
	ctx.save();
	ctx.shadowOffsetX = 1;
	ctx.shadowOffsetY = -1;
	ctx.fillStyle = fillColor[i];
	ctx.restore();
	oldAngle += wedge;
    }
}
function dashCanvas(x, y) {
    dataValue = [x, y];
    fillColor = ["#2980b9", "#2ecc71"];
 
    numSamples = 2;
    can = document.getElementById("dashCan");
    
    pieChart(dataValue, fillColor, can, numSamples);
}

function accCanvas(x, y) {
    dataValue = [x, y];
    fillColor = ["#2980b9", "#2ecc71"];
 
    numSamples = 2;
    can = document.getElementById("accCan");
    
    pieChart(dataValue, fillColor, can, numSamples);
}

function statCanvas(x, y, z) {
    fillColor = ["#3498db", "#f1c40f", "#2ecc71"];
    
    dataValue = [x, y, z];
    numSamples = 3;
    can = document.getElementById("statCan1");
    pieChart(dataValue, fillColor, can, numSamples);
    
    dataValue = [x, y, z];
    numSamples = 3;
    can = document.getElementById("statCan2");
    pieChart(dataValue, fillColor, can, numSamples);
    
    dataValue = [x, y, z];
    numSamples = 3;
    can = document.getElementById("statCan3");
    pieChart(dataValue, fillColor, can, numSamples);
    
    dataValue = [x, y, z];
    numSamples = 3;
    can = document.getElementById("statCan4");
    pieChart(dataValue, fillColor, can, numSamples);
}