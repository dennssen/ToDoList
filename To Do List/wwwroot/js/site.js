function NewSelectedColor(self, color){
    let target = document.getElementById("newColorInput")
    let background = document.getElementById("newTodolistheader")
    let colorList = self.parentElement.children
    
    for (i = 0; i < colorList.length; i++){
        colorList[i].style.border = "2px solid black"
    }
    
    self.style.border = "4px solid black"
    
    if (color === target.value) {
        color = "#ffffff"
        self.style.border = "2px solid black"
    }
    
    target.value = color
    background.style.backgroundColor = color
}

function OldSelectedColor(self, color, listId){
    let target = document.getElementById(`oldColorInput_${listId}`)
    let background = document.getElementById(`oldTodolistheader_${listId}`)
    let colorList = self.parentElement.children

    for (i = 0; i < colorList.length; i++){
        colorList[i].style.border = "2px solid black"
    }

    self.style.border = "4px solid black"

    if (color === target.value) {
        color = "#ffffff"
        self.style.border = "2px solid black"
    }

    target.value = color
    background.style.backgroundColor = color
}

function NewInsertPoint(){
    let pointContainer = document.getElementById("newPointContainer")

    const div = document.createElement("div")
    div.className = "point";
    
    const checkbox = document.createElement("input")
    checkbox.setAttribute("type", "checkbox")
    checkbox.setAttribute("onclick", "return false;")
    div.appendChild(checkbox)

    const inputBox = document.createElement("input")
    inputBox.setAttribute("name", "PointNames")
    inputBox.setAttribute("type", "text")
    inputBox.setAttribute("maxlength", "25")
    inputBox.setAttribute("placeholder", "Point 1")
    inputBox.setAttribute("required", "required")
    div.appendChild(inputBox);
    
    const icon = document.createElement("i")
    icon.setAttribute("class", "fa fa-trash")
    icon.setAttribute("style", "display: inline-block;")
    icon.setAttribute("type", "button")
    icon.setAttribute("onclick", "DeletePoint(this.parentElement, this.parentElement.parentElement.children.length)")
    div.appendChild(icon)
    
    pointContainer.appendChild(div)
}

function OldInsertPoint(listId){
    let pointContainer = document.getElementById(`oldPointContainer_${listId}`)

    const div = document.createElement("div")
    div.className = "point";

    const hidden = document.createElement("input")
    hidden.setAttribute("type", "hidden")
    hidden.setAttribute("name", "PointDones")
    hidden.setAttribute("value", "off")
    div.appendChild(hidden)
    
    const checkbox = document.createElement("input")
    checkbox.setAttribute("type", "checkbox")
    checkbox.setAttribute("name", "PointDones")
    checkbox.setAttribute("onclick", "return false;")
    div.appendChild(checkbox)

    const inputBox = document.createElement("input")
    inputBox.setAttribute("type", "text")
    inputBox.setAttribute("name", "PointNames")
    inputBox.setAttribute("maxlength", "25")
    inputBox.setAttribute("placeholder", "Point 1")
    inputBox.setAttribute("required", "required")
    div.appendChild(inputBox);

    const icon = document.createElement("i")
    icon.setAttribute("class", "fa fa-trash")
    icon.setAttribute("style", "display: inline-block;")
    icon.setAttribute("type", "button")
    icon.setAttribute("onclick", "DeletePoint(this.parentElement, this.parentElement.parentElement.children.length)")
    div.appendChild(icon)

    pointContainer.appendChild(div)
}

function DeletePoint(pointDiv, pointCount){
    console.log(pointCount)
    if (pointCount <= 1){
        return;
    }
    pointDiv.remove()
}