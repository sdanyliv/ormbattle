//var FullResult;
var CheckToolNames = [];
var VirtualForm = [];
var TestSelector;


function LoadOutputJson() {
  document.title = "Test Result";
  LoadJsonP("json/Output.json");
}

function ResultToMemory(json) {
  FullResult = json;
  RenderSelectBar();
}

function RenderSelectBar() {
  Parent = document.getElementById('SelectBar');
  for (var i = 0; i < FullResult[0].Tools.length; i++) {
    AddTool(FullResult[0].Tools[i],Parent);
  }
  
  TestSelector = document.createElement('select');
  TestSelector.id = 'Selector';
  for (var i = 1; i < FullResult.length; i++) {
    element = document.createElement('option');
    element.value = i;
    element.text = FullResult[i].Name;
    TestSelector.add(element);
  }
  Parent.appendChild(TestSelector);
}

function AddTool(tool, Parent) {
  var label = document.createElement('div');
  var checkBox = document.createElement('input');
  checkBox.type = 'CheckBox';
  checkBox.id = 'CheckToolGroup';
  checkBox.name = 'CheckToolGroup';
  checkBox.value = tool.ShortName;
  VirtualForm[VirtualForm.length] = checkBox;
  
  label.appendChild(checkBox);
  label.appendChild(document.createTextNode(tool.NAme + '(' + tool.ShortName + ')'));
  label.style.background = '#c5c5c5';  
  Parent.appendChild(label);
}


// Renderer

function Start() {
  CheckToolNames = [];
  document.getElementById('ResultsDisplay').innerHTML = '';
  for (var i = 0; i < VirtualForm.length;i++ ) {
    if (VirtualForm[i].checked) CheckToolNames[CheckToolNames.length] = VirtualForm[i].value;
  }
  RenderLINQResults();
  RenderPerfomanceResults()

  LoadJsonP("json/PerfomanceTable.json");
}

function RenderPerfomanceTable(tableTemplate) {
  var display = document.getElementById('TableDisplay');
  display.innerHTML = "";
  var scorecard = FullResult[document.getElementById('Selector').value];

  var rowController = HeadController(['min', 'max'], ['unit']);
  var table = CreateTable();

  table.AddRow(scorecard.Tools, 'ShortName', 'Test name', rowController);

//  var table = CreateTable();
  var rowController = RowLINQController(false, 'op/s');
  for (var i = 0; i < tableTemplate.length; i++) {
    rowController.Refresh();
    var rowAttr = tableTemplate[i];
    var testID = GetTestID(scorecard, rowAttr.TestName);
     
    if (rowAttr.Title == ' ') table.AddEmptyRow()
    if (rowAttr.TestName == ' ') table.AddRow([], '', rowAttr.Title, rowController);
    if (rowAttr.TestName == undefined) table.AddEmptyRow(rowAttr.Title);

    if (testID != undefined) {
      rowController.Unit = scorecard.Tests[testID].Unit;
      table.AddRow(scorecard.Tools, 'Results[' + testID + ']', rowAttr.Title, rowController, true); 
    }
//    display.appendChild(document.createTextNode(scorecard.Tests[testID].Name));
//    display.appendChild(document.createElement('br'));
  }
  

  display.appendChild(table);
}

function RenderLINQResults() {
  var scorecard = FullResult[0];
  var Display = document.getElementById('ResultsDisplay');
  var checkedTools = GetCheckedTools(scorecard);

  Display.appendChild(document.createTextNode(scorecard.Name));
  Display.appendChild(document.createElement('br'));

  var rowController = HeadController(['min', 'max'], ['unit']);
  var table = CreateTable();

  table.AddRow(scorecard.Tools, 'ShortName', 'Test name', rowController);
  table.AddEmptyRow('LINQ implementation:');
  for (var i = 0; i < scorecard.Tests.length; i++) {
    rowController = RowLINQController(true, scorecard.Tests[i].Unit);
    rowController.Max = scorecard.Tests[i].Maximum.First;
    table.AddRow(scorecard.Tools, 'Results[' + i + ']', scorecard.Tests[i].Name,rowController);
  }
  table.AddEmptyRow();
  table.AddEmptyRow('LINQ implementation total');
  rowController = RowLINQController(false,'#');
  table.AddRow(scorecard.Tools, 'Performed', 'Performed', rowController);
  table.AddRow(scorecard.Tools, 'Passed', 'Passed', rowController);
  rowController = RowLINQController(true, '#');
  table.AddRow(scorecard.Tools, 'Failed', 'Failed', rowController);
  rowController = RowLINQController(false, '#');
  rowController.Max = 100;
  table.AddRow(scorecard.Tools, 'Score', 'Score', rowController);

  Display.appendChild(table);

  var max = 0;
  var chartData = new Object();
  var dataSet = '&chd=t:';
  for (var i = 0; i < checkedTools.length; i++) {
    var result = _replaceChar(checkedTools[i].Score, ',', '.') + ',';
    if (max < parseFloat( result)) 
      max = result;
    dataSet = dataSet + result;
  }
  dataSet = dataSet.substr(0, dataSet.length - 1);

  chartData.Max = max;
  chartData.DataSet = dataSet;
  chartData.ChartTitle = 'LINQ implementation score';
  chartData.BarCount = CheckToolNames.length;
  chartData.Colors = ['356FB4']

  var img = document.createElement('img');
  var chURL = GetChartURL(chartData);
  img.src = chURL;
  Display.appendChild(img);
  RenderColorLabels(['Score'],['356FB4']);
}

function RenderPerfomanceResults() {
  var Display = document.getElementById('ResultsDisplay');
  var scorecard = FullResult[document.getElementById('Selector').value];
  var tmpTests;
  var tmpColors;

  var table = CreateTable();
  var rowController = RowLINQController(false, 'op/s');

  tmpTests = ["Compiled LINQ Query", "LINQ Query", "Native Query"];
  tmpColors = ['B83633','356FB4','8FB542'];
  var img1 = CreateStandartChart('Queries',tmpTests,tmpColors , scorecard);
  Display.appendChild(img1);
  RenderColorLabels(tmpTests, tmpColors);

  tmpTests = ["Get Small Page   (10 items)", "Get Average Page (20 items)", "Get Large Page   (50 items)", "Get Huge Page  (100 items)"];
  tmpColors =  [ '356FB4', 'B83633','8FB542','73529A'];
  var img2 = CreateStandartChart('Paging',tmpTests ,tmpColors, scorecard);
  Display.appendChild(img2);
  RenderColorLabels(tmpTests, tmpColors);

  tmpTests = ["LINQ Materialize", "Native Materialize"];
  tmpColors =  [ 'B83633','356FB4'];
  var img3 = CreateStandartChart('Materialisation',tmpTests ,tmpColors, scorecard);
  Display.appendChild(img3);
  RenderColorLabels(tmpTests, tmpColors);

  tmpTests = ["Fetch"];
  tmpColors =  ['356FB4'];
  var img4 = CreateStandartChart('Fetch',tmpTests ,tmpColors, scorecard);
  Display.appendChild(img4);
  RenderColorLabels(tmpTests, tmpColors);

  tmpTests = ["Create Instance [Single]", "Update Instance [Single]", "Remove Instance [Single]", "CUD Average [Single]"];
  tmpColors =  ['356FB4', 'B83633', '8FB542', '73529A'];
  var img5 = CreateStandartChart('CUD Single',tmpTests,tmpColors, scorecard);
  Display.appendChild(img5);
  RenderColorLabels(tmpTests, tmpColors);

  tmpTests = ["Create Instance [Multiple]", "Update Instance [Multiple]", "Remove Instance [Multiple]", "CUD Average [Multiple]"];
  tmpColors =  ['356FB4', 'B83633', '8FB542', '73529A'];
  var img6 = CreateStandartChart('CUD Multiple',tmpTests ,tmpColors, scorecard);
  Display.appendChild(img6);
  RenderColorLabels(tmpTests, tmpColors);
}

function RenderColorLabels(tests, colors) {
  var Display = document.getElementById('ResultsDisplay');
  var div = document.createElement('div');
  //div.style.width = 500;
  for (i = 0; i < tests.length; i++) {
    var lbl = document.createElement('label');
    lbl.innerHTML = ('█').fontcolor('#'+colors[i]);
    lbl.appendChild(document.createTextNode('-' + tests[i] + '   '));
    div.appendChild(lbl);
  }
  div.style.background = '#ffffff';
  Display.appendChild(div);
  Display.appendChild(document.createElement('br'));
  Display.appendChild(document.createElement('br'));
}


// Google charts

function CreateStandartChart(chartTitle, testList, colors, scorecard) {
  var chartData = CreateChartData(testList, scorecard);
  chartData.BarCount = testList.length * CheckToolNames.length;
  chartData.ChartTitle = chartTitle;
  chartData.Colors = colors;
  var chartURL = GetChartURL(chartData);
  var result = document.createElement('img');
  result.src = chartURL;
  return result;
}

function GetChartURL(chartData) {
  var baseBHGURL = 'http://chart.apis.google.com/chart?cht=bhg&chxt=y,x';
  var chDataLabel = '&chxl=' + '0:';
  for (var i = CheckToolNames.length-1; i >-1; i--)
    chDataLabel = chDataLabel + '|' + CheckToolNames[i];
  var chBarType = '&chbh=10,1,4';
  var chVerticalSize = '&chbh=' + '1,10,50';
  var chDataScale = '&chxr=' + '1,0,' + chartData.Max;
  var dataSise = '&chds=' + '0,' + chartData.Max;
  var chTitle = '&chtt=' + chartData.ChartTitle;
  var size = '&chs=' + '500x' + (chartData.BarCount * 12 + 50);
  var chColor = '&chco='+ chartData.Colors;

  return baseBHGURL + size + dataSise + chartData.DataSet + chTitle + chDataLabel + chDataScale + chBarType + chColor;
}

function CreateChartData(testList, scorecard) {
  var testsInndex = [];
  for (i = 0; i < testList.length; i++) {
  testsInndex[testsInndex.length] = GetTestID(scorecard,testList[i])
  }
  var chartData= new Object()
  var chData = '&chd=t:';
  var checkedTools = GetCheckedTools(scorecard);
  var max = 0;

  for (var i = 0; i < testsInndex.length; i++) {
    for (var j = 0; j < checkedTools.length; j++) {
      var result = GetResultData(checkedTools[j].Results[testsInndex[i]],true);
      if (max < result) max = result;
      chData = chData + result + ',';
    }
    chData = chData.substr(0, chData.length - 1) + '|';
  }
  chData = chData.substr(0, chData.length - 1);
  chartData.DataSet = chData;
  chartData.Max = max;
  return chartData;
}


// Misc

function GetTestID(scorecard, testName) {
  for (j = 0; j < scorecard.Tests.length; j++) {
    var tmpName = scorecard.Tests[j].Name;
    if (testName == tmpName) 
      return j;
  }
}

function GetResultData(result, returnInt) {
  var bb = CreateTable;

  if (result == null)
    if (returnInt) 
      return 0;
    else 
      return 'n/a';
  if (result.First == undefined) return result; 
  if (result.Second != 0 & ! returnInt) return result.First +'/'+ result.Second;
  return result.First;

}

function GetCheckedTools(scorecard) {
  var result = [];
  for ( i = 0; i < CheckToolNames.length; i++) { 
    result[result.length] = _getTool(CheckToolNames[i],scorecard);
  }
    return result;
  }

function GetPropertyFromPath(object, path) {
  var ob = object;
  var cursor = 0;
  for (var i = 0; i < path.length; i++) {
    if (path[i] == '.' || path[i] == ']' || path[i] == '[') {
      propertyName = path.substr(cursor, i - cursor);
      ob = ob[propertyName];
      cursor = i + 1;
    }
    if (path[i] == ']') { cursor++; i++ }
  }
  if (path[path.length - 1] != ']') {
    propertyName = path.substr(cursor, path.length);
    ob = ob[propertyName];
  }
  return ob;
}

function LoadJsonP(url) {
  var script = document.createElement('script');
  script.src = url;
  script.type = 'text/javascript';
  document.body.appendChild(script);
}

function _inChecked(tool) {
  var Display = document.getElementById('ResultsDisplay');
  for (var i = 0; i < CheckToolNames.length; i++) {
    if (CheckToolNames[i] == tool.ShortName) return true;
  }
  return false;
}

function _getTool(tShortName, scorecard) {
  for (var i = 0; i < scorecard.Tools.length; i++)
    if (tShortName == scorecard.Tools[i].ShortName) return scorecard.Tools[i];
}

function _pr(text) {
  var Display = document.getElementById('ResultsDisplay');
  Display.appendChild(document.createTextNode(text));
}

function _replaceChar(str, chr, newchr) {
  for (var i = 0; i < str.length; i++) {
    if (str[i] == chr) { 
      var result = str.substr(0, i) + newchr + str.substr(i + 1, str.length - i); 
    }
  }
  return result;
}


// Table routines

function CreateTable() {
  var value = '';
  var table = document.createElement('table');
  table.ColorIndex = 1;
  table.cellSpacing = 0;
  table.style.border = 'solid 1px #C2D69A';
  table.AddRow = function (dataArray, dataPath, rowName, controller, key) {
    var tr = document.createElement('tr');
    if (this.ColorIndex == 0) {
      tr.bgColor = 'white'; 
      this.ColorIndex = 1 
    }
    else { 
      tr.bgColor = '#EAF1DD'; 
      this.ColorIndex = 0 
    }
    if (rowName == undefined) 
      rowName = '';
    var name = CreateCell(rowName);
    tr.appendChild(name);
    if (dataArray != 0) 
      controller.PreRow(tr);
    else 
      name.colSpan = table.rows[0].cells.length;
    for (var i = 0; i < dataArray.length; i++) {
      if (dataPath != undefined) {
        value = GetPropertyFromPath(dataArray[i], dataPath);
        value = GetResultData(value);
      }
      else 
        value = dataArray[i];
      var td = CreateCell(value, 50);
      if (dataArray != 0) 
        controller.EditCell(td);
      tr.appendChild(td);
    }
    if (dataArray != 0) 
      controller.PostRow(tr);
    this.appendChild(tr);
  }
  table.AddEmptyRow = function (rowName) {
    var str = '_'
    var tr = document.createElement('tr');
    if (this.ColorIndex == 0) { tr.bgColor = 'white'; this.ColorIndex = 1 }
    else { tr.bgColor = '#EAF1DD'; this.ColorIndex = 0 }
    var td = document.createElement('td');
    if (rowName != undefined) {
      str = rowName;
      tr.bgColor = '#DDD9C3'
    }
    else td.style.color = 'white';
    td.innerHTML = str;
    td.style.border = 'solid 1px #C2D69A';
    if (table.rows[0] == undefined) { td.colSpan = 1; td.style.border = '0'; }
    else td.colSpan = table.rows[0].cells.length;
    tr.appendChild(td);
    this.appendChild(tr);
  }
  return table;
}

function CreateCell(value, width) {
  var result = document.createElement('td');
  
  if (value != undefined) 
    result.innerHTML = value;
  
  result.style.border = 'solid 1px #C2D69A';

  if (width != undefined)
    result.width = width;
  
  return result;
}


function HeadController(preHeader, postHeader)
{
  var result = new Object();
  result.PreHeader = preHeader;
  result.PostHeader = postHeader;
  
  result.PreRow = function (row) {
    row.bgColor = '#9BBB59';
    row.style.color = '#E9FEEE';
    row.firstChild.style.border = '0';
    for (var i = 0; i < this.PreHeader.length; i++) {
      var td = CreateCell(this.PreHeader[i], 50);
      td.style.border = '0';      
      row.appendChild(td);
    }
  }

  result.EditCell = function (cell) {
    cell.style.border = '0';
  }
  
  result.PostRow = function (row) {
    for (var i = 0; i < this.PostHeader.length; i++) {
      var td = CreateCell(this.PostHeader[i], 50);
      td.style.border = '0'; 
      row.appendChild(td);
    }

  }

  result.Refresh = function () { }
  
  return result;
}

function RowLINQController(back,unit) {
  var result = new Object();
  result.Unit = unit;
  result.Cells = [];
  result.Back = back;
  result.Max = 0;
  result.Min = 0;
  
  result.PreRow = function (row) {
    this.Cells[0] = CreateCell();
    this.Cells[1] = CreateCell();
    row.appendChild(this.Cells[0]);
    row.appendChild(this.Cells[1]);
  }
  
  result.EditCell = function (cell) {
    this.Cells[this.Cells.length] = cell;
    var value = parseFloat( cell.innerHTML);
    if (this.Max < value) this.Max = value;
  }
  
  result.PostRow = function (row) {
    this.Cells[0].innerHTML = this.Min;
    this.Cells[1].innerHTML = this.Max;

    for (var i = 0; i < this.Cells.length; i++) {
      var br = this.Cells[i];
      br.align = 'right';
      var value = br.innerHTML;
      if (value != 'n/a')
        if (this.Back) 
          br.bgColor = GetColorFromResult(this.Max, this.Min, value);
        else 
          br.bgColor = GetColorFromResult(this.Min, this.Max, value);
        else 
          br.bgColor = '#999999'
    }
    var td = CreateCell(this.Unit, 70);
    td.align = 'right';
    row.appendChild(td);
  }

  result.Refresh = function () {
    this.Max = 0;
    this.Cells = [];
  }

  return result;
}

function GetColorFromResult(min, max, value) {
  if (min != 0) 
    min = Math.log(min);
  if (max != 0) 
    max = Math.log(max);
  if (value != 0) 
    value = Math.log(value);

  var range = max - min;
  var absValue = value - min;
  kv = absValue / range;

  kg = 1;
  kr = 1;
  if (kv > 0.5) 
    kr = (1 - kv) * 2;
  else 
    kg = kv * 2;

  var color = Color();
  color.R = parseInt(kr * 255);
  color.G = parseInt(kg * 255);

  if (kg > kr) 
    color.B = kr * 255 / 2;
  else 
    color.B = kg * 255 / 2;

  return color.toString();
}

function Color() {
  var result = new Object();
  result.R = 0;
  result.G = 0;
  result.B = 0;
  result.toString = function () {
    var cstr = '#';
    cstr = cstr + HexColor(this.R);
    cstr = cstr + HexColor(this.G);
    cstr = cstr + HexColor(this.B);
    return cstr;
  }
  return result;
}

function HexColor(colorNum) {
  var result = '';
  var ost;
  for (; colorNum > 0; ) {
    ost = colorNum % 16;
    colorNum = (colorNum - ost) / 16;
    switch (ost) {
      case 0: result = '0' + result; break;
      case 2: result = '2' + result; break;
      case 3: result = '3' + result; break;
      case 4: result = '4' + result; break;
      case 5: result = '5' + result; break;
      case 6: result = '6' + result; break;
      case 7: result = '7' + result; break;
      case 8: result = '8' + result; break;
      case 9: result = '9' + result; break;
      case 10: result = 'A' + result; break;
      case 11: result = 'B' + result; break;
      case 12: result = 'C' + result; break;
      case 13: result = 'D' + result; break;
      case 14: result = 'E' + result; break;
      case 15: result = 'F' + result; break;
    }
  }
  for (; result.length < 2; )
    result = '0' + result;
  return result;
}
