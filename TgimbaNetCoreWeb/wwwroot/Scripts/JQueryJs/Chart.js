
function drawChart() {
    var results = GetDashboard();
    var userCnt = document.getElementById('UserCnt');
    userCnt.innerHTML = results[0];

    drawCategoryChart(results);
    drawAchievedChart(results);
    drawCreatedDateChart(results);
}  

function drawCategoryChart(results) {
    var data = google.visualization.arrayToDataTable([
      ['Category', 'Category'],
      ['Hot', Number(results[1])],
      ['Warm', Number(results[2])],
      ['Cool', Number(results[3])]
    ]);

    var options = {
        title: 'Categories'
    };

    var chart = new google.visualization.PieChart(document.getElementById('Category'));
    chart.draw(data, options);
}
function drawAchievedChart(results) {
    var data = google.visualization.arrayToDataTable([
        ['Achieved', 'Achieved'],
        ['True', Number(results[4])],
        ['False', Number(results[5])]
    ]);

    var options = {
        title: 'Achieved'
    };

    var chart = new google.visualization.PieChart(document.getElementById('Achieved'));
    chart.draw(data, options);

}
//TODO - Fix so the years are dynamic
function drawCreatedDateChart(results) {
    var data = google.visualization.arrayToDataTable([
        ['Created Year', 'Created Year'],
        ['2015', Number(results[6])],
        ['2016', Number(results[7])],
        ['2017', Number(results[8])]
    ]);

    var options = {
        title: 'Created Year'
    };

    var chart = new google.visualization.PieChart(document.getElementById('Created'));
    chart.draw(data, options);
}
