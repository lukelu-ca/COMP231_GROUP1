export interface IRecipe {
    id: number,
    name: string,
    cooking_Time: number,
    number_of_Services: number,
    calorie: number,
    mealTypeId: number,
    mealTypeName: string,
    viewed: number,
    postTime: Date,
    isPublic: boolean,
    pictureId: number,
    userId: number,
    userName: string,
    links: [
        {
            href: string,
            rel: string,
            method: string,
            isTemplated: boolean
        }
    ]
}