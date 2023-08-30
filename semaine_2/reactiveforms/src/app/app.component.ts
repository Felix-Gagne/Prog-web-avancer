import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, ValidationErrors, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'reactiveforms';

  constructor(private fb : FormBuilder){
  
  }

  form = this.fb.group({
    animal: ['', [Validators.required]],
    question: ['', [Validators.required, this.myCustomValidator]],
  });

  myCustomValidator(control: AbstractControl): ValidationErrors | null
  {
    //Récupère la valeur du champ texte
    const reponse = control.value;

    //Regarde si le champ est vide
    if(!reponse){
      return null;
    }

    //Regarde si la réponse est correct
    if(reponse.lowercase() == "oui" || reponse.lowercase() == "non")
    {
      control.setErrors(null);
    }
    else{
      control.setErrors({answerValidator:true});
    }

    return control.errors;
  }
}
