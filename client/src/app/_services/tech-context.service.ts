import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TechContextService {

  constructor() { }

  getTechContext(){
    return {
      workstationName:'MP00862562'
    };
  }
}
