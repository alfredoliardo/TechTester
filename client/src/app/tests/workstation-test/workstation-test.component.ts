import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TestInstance } from '../_models/test-instance';
import { TestsService } from '../_services/tests.service';

@Component({
  selector: 'app-workstation-test',
  templateUrl: './workstation-test.component.html',
  styleUrls: ['./workstation-test.component.scss']
})
export class WorkstationTestComponent implements OnInit {
  test: TestInstance | null = null;
  testId: string = '';
  workstationName: string = '';
  responseForm: FormGroup;

  constructor(
    private testsService: TestsService,
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder) {
    this.route.queryParams.subscribe(params => {
      this.testId = this.route.snapshot.params.testId;
      this.workstationName = this.route.snapshot.params.workstation;
    });
    this.responseForm = this.fb.group({
      testId: [this.testId, Validators.required],
      workstationName: [this.workstationName, Validators.required],
      responses: this.fb.array([])
    });
    this.testsService.getWorkstationTest(this.testId, this.workstationName).subscribe(response => {
      this.test = response;
      
      this.test?.checks.forEach(c => {
        
        this.responses.push(this.fb.group({
          checkName: [c.checkName],
          hasNeutralOption: [c.hasNeutralOption, Validators.required],
          checkId: [c.checkId, Validators.required],
          value: [c.value]
        }));
      });
    });
  }

  get responses(){
    return this.responseForm.get('responses') as FormArray;
  }

  ngOnInit(): void {

  }

  onSubmit():void {
    console.log(`Sending: ${JSON.stringify(this.responseForm.value)}`);
    this.router.navigate(['/']);
  }

}
