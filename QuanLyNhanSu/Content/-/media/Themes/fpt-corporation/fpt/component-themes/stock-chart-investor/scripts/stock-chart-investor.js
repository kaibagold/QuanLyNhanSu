function _defineProperty(obj, key, value) { if (key in obj) { Object.defineProperty(obj, key, { value: value, enumerable: true, configurable: true, writable: true }); } else { obj[key] = value; } return obj; }

// eslint-disable-next-line no-undef
var echartslib = echarts;
var langCode = jQuery("html").attr("lang") || "vi-VN";
var containerStockChartLanding = jQuery(".stock-chart-landing");
var getItemsFromCMS = jQuery("input#stock-chart-item-id").attr("value") || "3BA9C777-75AB-420A-920B-58756062693F";
var isLandingPage = jQuery(".stock-chart-landing");

(function () {
  function render() {
    //Render before call API
    containerStockChartLanding.toggleClass("loading");
    containerStockChartLanding.append("<div class=\"fpt-spinner\" style=\"margin: auto;\"></div>");
    jQuery.ajax({
      type: "GET",
      url: "api/sitecore/StockChart/GetStockChartInvestor?itemId=".concat(getItemsFromCMS, "&language=").concat(langCode),
      // url: `http://localhost:5000/api/admin/addquestion`,
      // url: `https://my-json-server.typicode.com/longlv91/mock-json/facets?f=type||category&l=${langCode}&s=${searchScope}&itemid=${itemId}&sc_site=${siteName}&e=0`,
      success: function success(respone) {
        if (respone.Title === null) {
          return;
        }

        containerStockChartLanding.toggleClass("loading");
        jQuery("div").remove(".fpt-spinner"); //Render chart

        var closingFinalPrice = 0;
        var volatilityIndex = 0;
        var classPriceUp = respone.PriceUp ? "price-up" : "price-down";
        var classIconArrow = respone.PriceUp ? "icon-triangle-top" : "icon-triangle-bottom"; //Convert format price

        var numberWithDot = function numberWithDot(str) {
          if (str) {
            return str.replaceAll(",", ".");
          } else {
            return "0.00";
          }
        };

        if (respone.ClosingPriceLatest) {
          closingFinalPrice = parseFloat(numberWithDot(respone.ClosingPriceLatest)) * 1000.0;
        }

        if (respone.VolatilityIndex) {
          var priceUpArray = [];

          if (respone.PriceUp) {
            priceUpArray = respone.VolatilityIndex.split("+");
          } else {
            priceUpArray = respone.VolatilityIndex.split("-");
          }

          volatilityIndex = parseFloat(numberWithDot(priceUpArray[1])) * 1000.0;
        }

        function numberWithCommas(str) {
          str = str.toString();
          var pattern = /(-?\d+)(\d{3})/;

          while (pattern.test(str)) {
            str = str.replace(pattern, "$1,$2");
          }

          return str;
        }

        jQuery(".chart-header-landing-content-price").addClass(classPriceUp);
        jQuery(".chart-header-landing-content-price i").addClass(classIconArrow);
        jQuery(".stock-chart-landing .chart-header-landing-title").text(respone.Title);
        jQuery(".stock-chart-landing .chart-header-landing-content-title").text(respone.ClosingPrice);
        jQuery(".stock-chart-landing .chart-header-landing-content-price .chart-header-landing-content-price__final-price").text(closingFinalPrice != 0 ? numberWithCommas(closingFinalPrice) + ".00" : "N/A");
        var showVolatilityIndexText = volatilityIndex !== 0 ? volatilityIndex != 0 ? (respone.PriceUp ? "+ " : "- ") + numberWithCommas(volatilityIndex) + ".00" : "0.00" : "0.00";
        jQuery(".stock-chart-landing .chart-header-landing-content-price .chart-header-landing-content-price__volatility").html("".concat(showVolatilityIndexText, "\n                    <span> (").concat(respone.VolatilityPercentage, ")</span>"));
        var dataDateArray = respone.CurrentDate.split("https://fpt.com/");
        var responseFormatDate = new Date(dataDateArray[2], dataDateArray[1] - 1, dataDateArray[0]);
        jQuery(".stock-chart-landing .chart-header-landing-content-date span").text(responseFormatDate.toLocaleDateString(langCode, {
          year: "numeric",
          month: "".concat(langCode == "en" ? "short" : "long"),
          day: "numeric"
        }));
        jQuery(".stock-chart-landing .col-12.chart-head").toggle();

        var genChartOptions = function genChartOptions(data, isMobie, isTablet) {
          var _xAxis;

          var breakHeight = isMobie ? 250 : isTablet ? 340 : 360;
          var options = {
            legend: false,
            tooltip: {
              trigger: "axis",
              textStyle: {
                color: '#101828',
                fontSize: '14',
                fontWeight: 'normal'
              },
              splitLine: {
                show: true
              },
              axisPointer: {
                type: 'cross',
                label: {
                  backgroundColor: '#101828',
                  color: '#FCFCFD',
                  formatter: function formatter(params) {
                    if (params.axisDimension == 'x') {
                      return echartslib.format.formatTime('dd/MM/yyyy', params.value);
                    } else if (params.axisDimension == 'y') {
                      return numberWithCommas(parseInt(params.value));
                    }
                  }
                }
              }
            },
            xAxis: (_xAxis = {
              show: true,
              position: "bottom",
              type: 'time',
              boundaryGap: false,
              splitLine: {
                show: false
              },
              axisTick: {
                inside: true
              },
              axisLabel: {
                color: "#101828",
                fontFamily: "Inter",
                borderDashOffset: "100",
                fontSize: isMobie ? 12 : 14,
                lineHeight: isMobie ? 15 : 17,
                formatter: function formatter(params) {
                  if (echartslib.format.formatTime('MM', params) !== '01') {
                    return echartslib.format.formatTime('MM', params);
                  } else {
                    return echartslib.format.formatTime('yyyy', params);
                  }
                }
              }
            }, _defineProperty(_xAxis, "splitLine", {
              show: false
            }), _defineProperty(_xAxis, "handle", {
              show: true,
              color: '#101828'
            }), _defineProperty(_xAxis, "z", 100), _xAxis),
            yAxis: {
              type: "value",
              show: true,
              max: function max(value) {
                Math.round(value.max / 1) + 5000;
              },
              min: function min(value) {
                return Math.round(value.min / 1000) * 1000 - 5000;
              },
              axisTick: {
                show: true
              },
              splitLine: {
                show: false
              },
              axisLine: {
                show: true
              },
              position: "right",
              axisLabel: {
                inside: false,
                formatter: "{value}",
                fontSize: "12",
                color: "#101828"
              },
              Interval: 5,
              z: 10
            },
            grid: {
              top: 10,
              left: "4",
              right: "53",
              height: breakHeight
            },
            series: [{
              type: 'line',
              smooth: 0.3,
              symbol: 'circle',
              symbolSize: 8,
              sampling: 'average',
              showSymbol: false,
              itemStyle: {
                fontSize: 30,
                color: "#FC7321"
              },
              stack: 'a',
              areaStyle: {
                color: new echartslib.graphic.LinearGradient(0, 0, 0, 1, [{
                  offset: 0,
                  color: "#EB7B3A"
                }, {
                  offset: 1,
                  color: "#FFFF"
                }])
              },
              emphasis: {
                focus: 'series'
              },
              data: data
            }]
          };
          return options;
        };
        /**
         * based on prepared DOM, initialize echarts instance
         */


        var chart = null; // Parse data from DOM

        var chartData = function chartData() {
          var chartArray = [];

          if (respone.StockChartData[0].data.xAxisData.data.length > 0) {
            respone.StockChartData[0].data.xAxisData.data.map(function (currentData, index) {
              var dataFormatDateArray = currentData.toString().split('.');
              var dataFormatDate = dataFormatDateArray[2] + "-" + dataFormatDateArray[1] + "-" + dataFormatDateArray[0];
              chartArray.push([dataFormatDate, parseInt(respone.StockChartData[0].data.yAxisData[0].data[index] * 1000.0)]);
            });
          }

          return chartArray;
        };

        var chartsContainer = jQuery(".stock-chart-landing .chart-container"); // Create Chart DOM

        var chartItemEle = document.createElement("div");
        chartItemEle.setAttribute("id", "chart1");
        chartsContainer.append(chartItemEle);

        var updateChart = function updateChart() {
          var isMobie = window.innerWidth <= 768;
          var isTablet = window.innerWidth > 768 && window.innerWidth <= 992;
          var data = chartData();

          if (chart && data) {
            chart.setOption(genChartOptions(data, isMobie, isTablet));
            setTimeout(function () {
              chart.resize();
            }, 500);
          }
        };

        if (chartsContainer.length === 1) {
          /**
           * use configuration item and data specified to show chart
           */
          window.onresize = function () {
            updateChart();
          };

          setTimeout(function () {
            // Initialize echarts instance
            var chartItemEle = document.getElementById("chart1");

            if (chartItemEle) {
              chart = echartslib.init(chartItemEle);
              window.dispatchEvent(new Event("resize"));
            }
          }, 1000);
        }
      }
    });
  } //Default view stock one year


  getItemsFromCMS && isLandingPage.length && render();
})(jQuery);