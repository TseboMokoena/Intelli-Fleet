$(function () {

    var rand100Factor = function () { return Math.round(Math.random() * 10000 + 15000) };
    //one line chart
    Morris.Line({
        element: 'morris-one-line-chart',
        data: [
            { month: '2016-01', value: rand100Factor() },
            { month: '2016-02', value: rand100Factor() },
            { month: '2016-03', value: rand100Factor() },
            { month: '2016-04', value: rand100Factor() },
            { month: '2016-05', value: rand100Factor() },
            { month: '2016-06', value: rand100Factor() },
            { month: '2016-07', value: rand100Factor() },
			{ month: '2016-08', value: rand100Factor() },
			{ month: '2016-09', value: rand100Factor() },
			{ month: '2016-10', value: rand100Factor() },
			{ month: '2016-11', value: rand100Factor() },
			{ month: '2016-12', value: rand100Factor() }
        ],
        //data: [
        //   { year: 'Jan', value: 5 },
        //   { year: 'Feb', value: 10 },
        //   { year: 'Mar', value: 8 },
        //   { year: 'Apr', value: 22 },
        //   { year: 'May', value: 8 },
        //   { year: 'June', value: 10 },
        //   { year: 'Jul', value: 5 },
        //   { year: 'Aug', value: 8 },
        //   { year: 'Sep', value: 12 },
        //   { year: 'Oct', value: 19 },
        //   { year: 'Nov', value: 12 },
        //  { year: 'Dec', value: 2 }
        //],
        xkey: 'month',
        ykeys: ['value'],
        resize: true,
        lineWidth: 4,
        labels: ['Value'],
        lineColors: ['#df3d82'],
        pointSize: 5
    });

    //line chart
    Morris.Line({
        element: 'morris-line-chart',
        data: [{ y: '2016-01', a: 1000 + 1000, b: 900 + 1000 },
            { y: '2016-02', a: 750 + 1000, b: 650 + 1000 },
            { y: '2016-03', a: 500 + 1000, b: 400 + 1000 },
            { y: '2016-04', a: 750 + 1000, b: 650 + 1000 },
            { y: '2016-05', a: 500 + 1000, b: 400 + 1000 },
            { y: '2016-06', a: 750 + 1000, b: 650 + 1000 },
			{ y: '2016-07', a: 1105 + 1000, b: 256 + 1000 },
			{ y: '2016-08', a: 1400 + 1000, b: 1250 + 1000 },
			{ y: '2016-09', a: 950 + 1000, b: 750 + 1000 },
			{ y: '2016-10', a: 665 + 1000, b: 500 + 1000 },
			{ y: '2016-11', a: 800 + 1000, b: 600 + 1000 },
            { y: '2016-12', a: 1550 + 1000, b: 1300 + 1000 }],
        xkey: 'y',
        ykeys: ['a', 'b'],
        labels: ['Current Year', 'Previous Year'],
        hideHover: 'auto',
        resize: true,
        lineColors: ['#55b3ee', '#df3d82']
    });

    //bar charts
    Morris.Bar({
        element: 'morris-bar-chart',
        data: [
            { y: 'Jan', a: 8000 + 1000, b: 7000 + 1000 },
            { y: 'Feb', a: 5000 + 1000, b: 4000 + 1000 },
            { y: 'Mar', a: 7500 + 1000, b: 6500 + 1000 },
            { y: 'Apr', a: 5000 + 1000, b: 4000 + 1000 },
            { y: 'May', a: 7500 + 1000, b: 6500 + 1000 },
            { y: 'Jun', a: 10000 + 1000, b: 9000 + 1000 },
			{ y: 'Jul', a: 2000 + 1000, b: 1500 + 1000 },
			{ y: 'Aug', a: 8000 + 1000, b: 5550 + 1000 },
			{ y: 'Sep', a: 1250 + 1000, b: 1300 + 1000 },
			{ y: 'Oct', a: 9000 + 1000, b: 9000 + 1000 },
			{ y: 'Nov', a: 8000 + 1000, b: 1050 + 1000 },
			{ y: 'Dec', a: 4000 + 1000, b: 9900 + 1000 }],
        xkey: 'y',
        ykeys: ['a', 'b'],
        labels: ['Current Year', 'Previous Year'],
        hideHover: 'auto',
        resize: true,
        barColors: ['#df3d82', '#cacaca']
    });
});

