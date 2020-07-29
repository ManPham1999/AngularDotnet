import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";

@Component({
  selector: "app-create-hero",
  templateUrl: "./create-hero.component.html",
  styleUrls: ["./create-hero.component.css"],
})
export class CreateHeroComponent implements OnInit {
  powertype: string;
  powerlevel: string;
  gender: string;
  constructor(private http: HttpClient, private router: Router) {}

  ngOnInit() {}
  onSubmit = () => {
    this.http
      .post(`https://localhost:5001/api/Heros`, {
        powertype: this.powertype,
        powerlevel: parseInt(this.powerlevel),
        gender: this.gender ? (this.gender === "1" ? true : false) : "",
      })
      .subscribe(
        (item) => {
          console.log(item);
          if (item) {
            this.router.navigate([""]);
            alert("success !");
          }
        },
        (error) => {
          console.error(error.statusText);
          alert(error.statusText);
        }
      );
  };
}
