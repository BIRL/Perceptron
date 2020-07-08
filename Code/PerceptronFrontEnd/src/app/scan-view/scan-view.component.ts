import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { ConfigService } from '../config.service';


@Component({
  selector: 'app-scan-view',
  templateUrl: './scan-view.component.html',
  styleUrls: ['./scan-view.component.css'],
  providers: [ConfigService]
})
export class ScanViewComponent implements OnInit {
  displayedColumns = ['serial', 'name', 'id', 'score', 'molW', 'truncation', 'frags', 'mods','mix', 'fileId'];
  dataSource: MatTableDataSource<UserData>;
  querryId: any;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private route: ActivatedRoute, private router: Router, private _httpService: ConfigService) {
    const users: UserData[] = [];
    this.dataSource = new MatTableDataSource(users);
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
    this.dataSource.filter = filterValue;
  }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => this.querryId = params['querryId']);
    this._httpService.GetScanReslts(this.querryId).subscribe(data => this.what(data));
  }

  ResultsDownload(){
    this._httpService.GetResultsDownload(this.querryId).subscribe(data => this.what(data));
  }

  what(data: any) {
    const users: UserData[] = [];
    for (let i = 1; i <= data.length; i++) { users.push(createNewUser(i, data[i - 1])); }
    this.dataSource = new MatTableDataSource(users);


    let title = <HTMLLabelElement>document.getElementById("SearchTitle");
    title.innerHTML = data.Paramters.SearchParameters.Title;
   
    let pdb = <HTMLLabelElement>document.getElementById("ProteinDB");
    pdb.innerHTML = data.Paramters.SearchParameters.ProtDb;


    let protTol = <HTMLLabelElement>document.getElementById("protTol");
    protTol.innerHTML = data.Paramters.SearchParameters.MwTolerance;

    let autotunee = <HTMLLabelElement>document.getElementById("Tuner");            
    autotunee.innerHTML = data.Paramters.SearchParameters.Autotune;

    let ppeptol = <HTMLLabelElement>document.getElementById("peptol");            
    ppeptol.innerHTML = data.Paramters.SearchParameters.HopThreshhold;  

    let fragt = <HTMLLabelElement>document.getElementById("FragType");            
    fragt.innerHTML = data.Paramters.SearchParameters.InsilicoFragType; 

    let SpecI = <HTMLLabelElement>document.getElementById("SI");            
    SpecI.innerHTML = data.Paramters.SearchParameters.HandleIons; 

    let DenovAllow = <HTMLLabelElement>document.getElementById("PST");            
    DenovAllow.innerHTML = data.Paramters.SearchParameters.DenovoAllow;

    let PstLength = <HTMLLabelElement>document.getElementById("PSTLen");            
    PstLength.innerHTML = data.Paramters.SearchParameters.MinimumPstLength + " " + data.Paramters.SearchParameters.MaximumPstLength ;

    let IPMSWeight = <HTMLLabelElement>document.getElementById("Slider1");
    let PSTWeight = <HTMLLabelElement>document.getElementById("Slider2");
    let SpecCompWeight = <HTMLLabelElement>document.getElementById("Slider3");

    IPMSWeight.innerHTML = data.Results.Results.MwScore;
    PSTWeight.innerHTML = data.Results.Results.PstScore;
    SpecCompWeight.innerHTML = data.Results.Results.InsilicoScore;
  
  }


  getRecord(row) {
    let x = this.router;
    x.navigate(["summaryresults", this.querryId, row.fileId]);
  }
}

/** Builds and returns a new User. */
function createNewUser(id: number, data: any): UserData {
  return {
    serial: id.toString(),
    name: data.FileName,
    id: data.ProteinId,
    score: data.Score,
    molW: data.MolW,
    truncation: data.Truncation,
    frags: data.Frags,
    mods: data.Mods,
    mix:data.Time,
    fileId: data.FileId
  };
}

export interface UserData {
  serial: string;
  name: string;
  id: string;
  score: string;
  molW: string;
  truncation: string;
  frags: string;
  mods: string;
  fileId: string;
  mix:string;
}