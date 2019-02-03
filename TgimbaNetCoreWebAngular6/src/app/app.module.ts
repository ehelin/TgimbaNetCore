import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ModuleWithProviders  } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';	  
import { HttpClientModule } from '@angular/common/http'	  
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { MainComponent } from './components/main/main.component';  
import { MenuComponent } from './components/menu/menu.component';
import { SessionComponent } from './components/common/session.component';
import { ConstantsComponent } from './components/common/constants.component';
import { UtilitiesComponent } from './components/common/utilities.component';
import { AddComponent } from './components/add/add.component';

const routes: Routes = [
	{ path: 'login',  component: LoginComponent },
	{ path: 'registration', component: RegistrationComponent },
	{ path: 'main', component: MainComponent },
	{ path: 'menu', component: MenuComponent },
	{ path: 'add', component: AddComponent }
];

@NgModule({
	declarations: [
		AppComponent,
		LoginComponent,
		RegistrationComponent,
		MainComponent,
		MenuComponent,
		SessionComponent,
		ConstantsComponent,
		UtilitiesComponent,
		AddComponent
		//ApplicationFlowComponent
	],
	imports: [
		BrowserModule,
		FormsModule,
		HttpClientModule, 
		RouterModule.forRoot(routes),
	],		
	providers: [],
	bootstrap: [AppComponent],
	exports: [RouterModule]
})		   
export class AppModule {}
