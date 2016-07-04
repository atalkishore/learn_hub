import {Component} from "angular2/core"
import {MyModel} from "./model"

@Component({
    selector: `my-app`,
    template: `<div>Hello from {{getCompiler()}}</div>`
})
export class MyApp {
    model = new MyModel();
    title = this.model.compiler;
    getCompiler() {
        return this.model.compiler;
    }
}