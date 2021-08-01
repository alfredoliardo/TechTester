import { Component, OnInit } from '@angular/core';
import { TechContextService } from 'src/app/_services/tech-context.service';
import { TestInstance } from '../_models/test-instance';
import { TestsService } from '../_services/tests.service';

@Component({
  selector: 'app-workstation-dashboard',
  templateUrl: './workstation-dashboard.component.html',
  styleUrls: ['./workstation-dashboard.component.scss']
})
export class WorkstationDashboardComponent implements OnInit {
  tests:TestInstance[] = [];
  constructor(private tc:TechContextService, private test:TestsService) { }

  ngOnInit(): void {
    var context = this.tc.getTechContext();
    this.test.getWorkstationTests(context.workstationName).subscribe((response) => {
      this.tests = response;
    });
  }

}
